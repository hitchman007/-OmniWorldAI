using UnityEngine;

namespace OnlyWar {
  public enum OnlyWarPerkType { Lightweight, Ghost, Deadeye, FastRecovery, Engineer, Scavenger, TacticalMask, Hardline }

  public sealed class OnlyWarPerks : MonoBehaviour {
    public OnlyWarPerkType perk1=OnlyWarPerkType.Lightweight;
    public OnlyWarPerkType perk2=OnlyWarPerkType.Ghost;
    public OnlyWarPerkType perk3=OnlyWarPerkType.Deadeye;

    public float MoveMultiplier=>perk1==OnlyWarPerkType.Lightweight?1.07f:1f;
    public float ScoreMultiplier=>perk3==OnlyWarPerkType.Hardline?1.18f:1f;
    public float RecoveryMultiplier=>perk1==OnlyWarPerkType.FastRecovery?1.35f:1f;
    public bool HiddenFromUav=>perk2==OnlyWarPerkType.Ghost;
    public bool ShowEquipment=>perk2==OnlyWarPerkType.Engineer;
    public bool ScavengeAmmo=>perk3==OnlyWarPerkType.Scavenger;
    public bool TacticalResist=>perk3==OnlyWarPerkType.TacticalMask;
  }
}
