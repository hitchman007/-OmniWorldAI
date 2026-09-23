using System;
using UnityEngine;

namespace OnlyWar {
  [Serializable] public sealed class OnlyWarOperatorData {
    public string id;
    public string displayName;
    public string role;
    public string biography;
    public string[] skins;
  }

  [Serializable] public sealed class OnlyWarVehicleData {
    public string id;
    public string displayName;
    public string category;
    public float topSpeed;
    public int seats;
    public string[] skins;
  }

  [CreateAssetMenu(menuName="OnlyWar/Operator Catalog")]
  public sealed class OnlyWarOperatorCatalog : ScriptableObject {
    public OnlyWarOperatorData[] operators;
  }

  [CreateAssetMenu(menuName="OnlyWar/Vehicle Catalog")]
  public sealed class OnlyWarVehicleCatalog : ScriptableObject {
    public OnlyWarVehicleData[] vehicles;
  }

  [CreateAssetMenu(menuName="OnlyWar/Weapon Catalog")]
  public sealed class OnlyWarWeaponCatalog : ScriptableObject {
    public OnlyWarWeaponDefinition[] weapons;
  }
}
