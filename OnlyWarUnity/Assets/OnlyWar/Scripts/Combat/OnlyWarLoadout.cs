using System;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  [Serializable] public sealed class OnlyWarAttachment {
    public string id;
    public string slot;
    public float recoilMultiplier = 1f;
    public float adsMultiplier = 1f;
    public int magazineBonus;
  }

  [Serializable] public sealed class OnlyWarLoadout {
    public string name = "ASSAULT";
    public OnlyWarWeaponDefinition primary;
    public OnlyWarWeaponDefinition secondary;
    public List<OnlyWarAttachment> attachments = new();
    public string tactical = "FLASH";
    public string lethal = "FRAG";
    public string fieldUpgrade = "DEPLOYABLE_COVER";
    public string scorestreak1 = "UAV";
    public string scorestreak2 = "DRONE";
    public string scorestreak3 = "AIRSTRIKE";
  }

  public sealed class OnlyWarLoadoutService : MonoBehaviour {
    public List<OnlyWarLoadout> loadouts = new();
    public int activeIndex;
    public OnlyWarLoadout Active => loadouts.Count == 0 ? null : loadouts[Mathf.Clamp(activeIndex,0,loadouts.Count-1)];

    public bool EquipAttachment(OnlyWarAttachment attachment) {
      if (Active == null || attachment == null) return false;
      Active.attachments.RemoveAll(a => a.slot == attachment.slot);
      if (Active.attachments.Count >= 5) return false;
      Active.attachments.Add(attachment);
      return true;
    }

    public void Select(int index) => activeIndex = Mathf.Clamp(index,0,Mathf.Max(0,loadouts.Count-1));
  }
}
