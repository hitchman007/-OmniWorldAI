using System;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  [Serializable] public sealed class OnlyWarLootItem {
    public string id;
    public string displayName;
    public int value;
    public int rarity;
    public bool contraband;
  }

  public sealed class OnlyWarExtractionInventory : MonoBehaviour {
    public int backpackSlots = 16;
    public List<OnlyWarLootItem> backpack = new();
    public List<OnlyWarLootItem> stash = new();

    public bool Loot(OnlyWarLootItem item) {
      if (item == null || backpack.Count >= backpackSlots) return false;
      backpack.Add(item); return true;
    }

    public void ExtractSuccess() {
      stash.AddRange(backpack);
      backpack.Clear();
    }

    public void LostInAction() {
      backpack.RemoveAll(x => x == null || x.contraband);
      backpack.Clear();
    }

    public int BackpackValue() {
      int total=0; foreach (var x in backpack) if (x!=null) total += x.value; return total;
    }
  }
}
