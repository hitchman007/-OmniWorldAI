using UnityEngine;
using System.Collections.Generic;

public class OmniWorldFactionSystem : MonoBehaviour
{
    public List<string> factions = new List<string>();

    void Start()
    {
        CreateDefaultFactions();
    }

    void CreateDefaultFactions()
    {
        factions.Add("Omni Guardians");
        factions.Add("AI Explorers");
        factions.Add("World Builders");

        Debug.Log("Faction System Activated");
    }

    public void CreateFaction(string factionName)
    {
        if (!factions.Contains(factionName))
        {
            factions.Add(factionName);

            Debug.Log("Faction Created: " + factionName);
        }
    }

    public void RemoveFaction(string factionName)
    {
        if (factions.Contains(factionName))
        {
            factions.Remove(factionName);

            Debug.Log("Faction Removed: " + factionName);
        }
    }

    public bool HasFaction(string factionName)
    {
        return factions.Contains(factionName);
    }

    public int GetFactionCount()
    {
        return factions.Count;
    }
}