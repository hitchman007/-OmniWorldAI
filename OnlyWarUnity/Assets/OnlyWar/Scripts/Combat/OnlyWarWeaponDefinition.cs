using UnityEngine;

namespace OnlyWar {
  [CreateAssetMenu(menuName="OnlyWar/Weapon Definition")]
  public sealed class OnlyWarWeaponDefinition : ScriptableObject {
    public string weaponId = "ARX-41";
    public int magazine = 30;
    public int reserve = 150;
    public float damage = 32f;
    public float headMultiplier = 1.65f;
    public float rpm = 700f;
    public float reloadSeconds = 1.55f;
    public float range = 180f;
    public float hipSpread = 1.25f;
    public float adsSpread = .22f;
    public float recoilPitch = 1.1f;
    public float recoilYaw = .35f;
    public AudioClip fireClip;
    public AudioClip reloadClip;
    public GameObject muzzleFx;
    public GameObject impactFx;
    public GameObject firstPersonPrefab;
  }
}
