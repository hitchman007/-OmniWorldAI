using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarWeaponFX : MonoBehaviour {
    public Transform ejectionPort;
    public GameObject casingPrefab;
    public OnlyWarVFXFactory vfx;
    public OnlyWarProceduralAudio audioFx;
    public OnlyWarWeaponAnimator animator;
    public Camera cameraRef;
    Vector3 shake;
    float shakeT;

    void Awake(){
      if(!vfx)vfx=FindFirstObjectByType<OnlyWarVFXFactory>();
      if(!audioFx)audioFx=FindFirstObjectByType<OnlyWarProceduralAudio>();
      if(!cameraRef)cameraRef=Camera.main;
    }

    public void Fire(string weaponId,Transform muzzle,float recoil=1f){
      vfx?.CreateMuzzleFlash(muzzle)?.Play();
      audioFx?.PlayGun(weaponId,muzzle?muzzle.position:transform.position);
      animator?.Kick(recoil);
      shakeT=.07f;shake+=new Vector3(Random.Range(-.35f,.35f),Random.Range(.2f,.6f),0)*recoil;
      if(casingPrefab&&ejectionPort){
        var c=Instantiate(casingPrefab,ejectionPort.position,ejectionPort.rotation);
        if(c.TryGetComponent<Rigidbody>(out var rb))rb.AddForce((ejectionPort.right+Vector3.up*.4f)*Random.Range(1.5f,2.4f),ForceMode.Impulse);
        Destroy(c,3f);
      }
    }

    void LateUpdate(){
      if(!cameraRef)return;
      if(shakeT>0){shakeT-=Time.deltaTime;cameraRef.transform.localRotation*=Quaternion.Euler(shake);}
      shake=Vector3.Lerp(shake,Vector3.zero,20f*Time.deltaTime);
    }
  }
}
