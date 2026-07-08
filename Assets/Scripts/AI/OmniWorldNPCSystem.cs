using UnityEngine;
using System.Collections.Generic;

public class OmniWorldNPCSystem : MonoBehaviour
{
    public List<string> npcCharacters = new List<string>();

    void Start()
    {
        CreateNPCs();
    }

    void CreateNPCs()
    {
        npcCharacters.Add("AI Explorer");
        npcCharacters.Add("AI Merchant");
        npcCharacters.Add("AI Guardian");

        Debug.Log("NPC System Activated");
    }

    public void AddNPC(string npcName)
    {
        npcCharacters.Add(npcName);

        Debug.Log("NPC Created: " + npcName);
    }

    public void RemoveNPC(string npcName)
    {
        if (npcCharacters.Contains(npcName))
        {
            npcCharacters.Remove(npcName);

            Debug.Log("NPC Removed: " + npcName);
        }
    }

    public int GetNPCCount()
    {
        return npcCharacters.Count;
    }
}