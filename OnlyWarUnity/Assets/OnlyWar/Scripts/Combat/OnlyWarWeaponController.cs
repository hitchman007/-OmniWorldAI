using System.Collections;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarWeaponController : MonoBehaviour {
    public OnlyWarInput input;
    public Camera aimCamera;
    public OnlyWarWeaponDefinition[] loadout;
    public int slot;
    public LayerMask hitMask = ~0;
    public Transform weaponSocket;
    public Transform muzzleSocket;
    public OnlyWarWeaponFX fx;
    public OnlyWarHitFeedback hitFeedback;

    int mag, reserve;
    float nextShot;
    bool reloading;
    GameObject viewModel;

    public OnlyWarWeaponDefinition Current => loadout != null && loadout.Length > 0 ? loadout[Mathf.Clamp(slot,0,loadout.Length-1)] : null;

    void Start() {
      if (!input) input = FindFirstObjectByType<OnlyWarInput>();
      if (!aimCamera) aimCamera = Camera.main;
      Equip(0);
    }

    void Update() {
      if (!input || Current == null) return;
      if (input.SwapPressed && loadout.Length > 1) Equip((slot + 1) % loadout.Length);
      if (input.ReloadPressed) StartReload();
      if (input.FireHeld) Fire();
      OnlyWarGame.I?.hud?.RefreshWeapon(Current.weaponId, mag, reserve, reloading);
    }

    public void Equip(int index) {
      if (loadout == null || loadout.Length == 0) return;
      slot = Mathf.Clamp(index, 0, loadout.Length - 1);
      StopAllCoroutines(); reloading = false;
      mag = Current.magazine; reserve = Current.reserve;
      if (viewModel) Destroy(viewModel);
      if (Current.firstPersonPrefab && weaponSocket) viewModel = Instantiate(Current.firstPersonPrefab, weaponSocket);
    }

    void Fire() {
      if (reloading || Time.time < nextShot) return;
      if (mag <= 0) { StartReload(); return; }
      nextShot = Time.time + 60f / Mathf.Max(1f, Current.rpm);
      mag--;

      float spread = input.AdsHeld ? Current.adsSpread : Current.hipSpread;
      Vector2 jitter = Random.insideUnitCircle * spread;
      Ray ray = aimCamera.ViewportPointToRay(new Vector3(.5f + jitter.x/100f, .5f + jitter.y/100f, 0f));
      bool didHit=false, didHead=false;
      if (Physics.Raycast(ray, out var hit, Current.range, hitMask, QueryTriggerInteraction.Ignore)) {
        var dmg = hit.collider.GetComponentInParent<OnlyWarDamageable>();
        if (dmg) {
          bool headshot = dmg.head && (hit.collider.transform == dmg.head || hit.collider.transform.IsChildOf(dmg.head));
          dmg.ApplyDamage(Current.damage * (headshot ? Current.headMultiplier : 1f), headshot);
          didHit=true;didHead=headshot;
        }
        if (Current.impactFx) Instantiate(Current.impactFx, hit.point, Quaternion.LookRotation(hit.normal));
        else FindFirstObjectByType<OnlyWarVFXFactory>()?.CreateImpact(hit.point,hit.normal);
      }
      if (Current.muzzleFx && weaponSocket) Instantiate(Current.muzzleFx, weaponSocket.position, weaponSocket.rotation, weaponSocket);
      if (Current.fireClip) AudioSource.PlayClipAtPoint(Current.fireClip, transform.position, .8f);
      else FindFirstObjectByType<OnlyWarProceduralAudio>()?.PlayGun(Current.weaponId,transform.position);
      if(!fx)fx=GetComponent<OnlyWarWeaponFX>();
      fx?.Fire(Current.weaponId,muzzleSocket?muzzleSocket:weaponSocket,Current.recoilPitch);
      if(didHit){
        if(!hitFeedback)hitFeedback=FindFirstObjectByType<OnlyWarHitFeedback>();
        hitFeedback?.ShowHit(didHead);
        FindFirstObjectByType<OnlyWarHaptics>()?.Shot(.55f);
      }
    }

    void StartReload() {
      if (!reloading && mag < Current.magazine && reserve > 0) StartCoroutine(Reload());
    }

    IEnumerator Reload() {
      reloading = true;
      if (Current.reloadClip) AudioSource.PlayClipAtPoint(Current.reloadClip, transform.position);
      else FindFirstObjectByType<OnlyWarProceduralAudio>()?.PlayReload(transform.position);
      yield return new WaitForSeconds(Current.reloadSeconds);
      int need = Current.magazine - mag, take = Mathf.Min(need, reserve);
      mag += take; reserve -= take; reloading = false;
    }
  }
}
