using UnityEngine;
using System.Collections.Generic;

public class OmniWorldReputationSystem : MonoBehaviour
{
    public int reputation = 0;

    public Dictionary<string, int> factionReputation =
        new Dictionary<string, int>();

    void Start()
    {
        InitializeReputation();
    }

    void InitializeReputation()
    {
        factionReputation.Add("Omni Guardians", 0);
        factionReputation.Add("AI Explorers", 0);
        factionReputation.Add("World Builders", 0);

        Debug.Log("Reputation System Activated");
    }

    public void ChangeReputation(string faction, int amount)
    {
        if (factionReputation.ContainsKey(faction))
        {
            factionReputation[faction] += amount;

            Debug.Log(
                "Reputation Changed: " + faction +
                " " + factionReputation[faction]
            );
        }
    }

    public int GetFactionReputation(string faction)
    {
        if (factionReputation.ContainsKey(faction))
        {
            return factionReputation[faction];
        }

        return 0;
    }

    public void AddGlobalReputation(int amount)
    {
        reputation += amount;

        Debug.Log("Global Reputation: " + reputation);
    }
}