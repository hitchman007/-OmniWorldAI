using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  [System.Serializable] public sealed class OnlyWarShopItem {
    public string id;
    public int price;
    public OnlyWarLootItem loot;
  }

  public sealed class OnlyWarBuyStation : MonoBehaviour {
    public List<OnlyWarShopItem> stock = new();

    public bool Buy(string itemId, ref int cash, OnlyWarExtractionInventory inventory) {
      var item = stock.Find(x => x.id == itemId);
      if (item == null || cash < item.price || !inventory) return false;
      if (!inventory.Loot(item.loot)) return false;
      cash -= item.price;
      return true;
    }
  }
}
