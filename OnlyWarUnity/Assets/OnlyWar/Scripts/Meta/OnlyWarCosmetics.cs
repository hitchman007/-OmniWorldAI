using System;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public enum CosmeticType { OperatorSkin, WeaponCamo, VehicleSkin, Charm, CallingCard, Emblem }

  [Serializable] public sealed class OnlyWarCosmetic {
    public string id;
    public string displayName;
    public CosmeticType type;
    public int price;
    public int rarity;
    public Material material;
    public GameObject prefab;
  }

  [CreateAssetMenu(menuName="OnlyWar/Cosmetic Catalog")]
  public sealed class OnlyWarCosmeticCatalog : ScriptableObject {
    public OnlyWarCosmetic[] items;
  }

  public sealed class OnlyWarCosmeticInventory : MonoBehaviour {
    public int credits=2400;
    public OnlyWarCosmeticCatalog catalog;
    public List<string> owned=new();
    public string operatorSkin,weaponCamo,vehicleSkin;

    public bool Purchase(string id){
      var item=Array.Find(catalog.items,x=>x.id==id);if(item==null||owned.Contains(id)||credits<item.price)return false;
      credits-=item.price;owned.Add(id);return true;
    }
    public bool Equip(string id){
      if(!owned.Contains(id))return false;var item=Array.Find(catalog.items,x=>x.id==id);if(item==null)return false;
      if(item.type==CosmeticType.OperatorSkin)operatorSkin=id;
      else if(item.type==CosmeticType.WeaponCamo)weaponCamo=id;
      else if(item.type==CosmeticType.VehicleSkin)vehicleSkin=id;
      return true;
    }
  }
}
