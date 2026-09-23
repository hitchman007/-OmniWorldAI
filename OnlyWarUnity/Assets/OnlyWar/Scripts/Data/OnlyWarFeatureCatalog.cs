using System;
using UnityEngine;

namespace OnlyWar {
  [CreateAssetMenu(menuName="OnlyWar/Feature Catalog")]
  public sealed class OnlyWarFeatureCatalog : ScriptableObject {
    public string seasonName = "REACH";
    public string[] multiplayerModes = { "Team Strike", "Frontline", "Search & Destroy", "Kill Confirmed", "Hardpoint", "Free For All" };
    public string[] metaSystems = { "Loadouts", "Gunsmith", "Operators", "Vehicle Garage", "Ranked", "Clans", "Battle Pass", "Seasonal Events", "Store", "Challenges", "Stats", "Friends", "Voice Chat" };
    public string[] battleRoyaleSystems = { "Squads", "Armor", "Loot", "Classes", "Vehicles", "Buy Stations", "Contracts", "Revive", "Safe Zone", "Airdrops" };
    public string[] extractionSystems = { "PvPvE", "Contracts", "Stash", "Crafting", "Bosses", "Buy Stations", "Extraction", "Persistent Loot", "Faction Missions", "High-Risk Zones" };
  }
}
