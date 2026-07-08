using System.Collections.Generic;
using UnityEngine;

public class OmniWorldPartySystem : MonoBehaviour
{
    [Header("Party System")]
    public int maxPartyMembers = 4;
    public List<string> partyMembers = new List<string>();

    public int PartySize
    {
        get { return partyMembers.Count; }
    }

    private void Start()
    {
        Debug.Log("OmniWorld Party System initialized.");
    }

    public bool CreateParty(string leaderName)
    {
        if (string.IsNullOrEmpty(leaderName))
        {
            Debug.LogWarning("Party creation failed: leader name is empty.");
            return false;
        }

        partyMembers.Clear();
        partyMembers.Add(leaderName);

        Debug.Log("Party created by: " + leaderName);
        return true;
    }

    public bool AddMember(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            return false;
        }

        if (partyMembers.Count >= maxPartyMembers)
        {
            Debug.LogWarning("Party is full.");
            return false;
        }

        if (partyMembers.Contains(playerName))
        {
            return false;
        }

        partyMembers.Add(playerName);
        Debug.Log(playerName + " joined the party.");
        return true;
    }

    public void RemoveMember(string playerName)
    {
        if (partyMembers.Contains(playerName))
        {
            partyMembers.Remove(playerName);
            Debug.Log(playerName + " left the party.");
        }
    }

    public bool IsPartyFull()
    {
        return partyMembers.Count >= maxPartyMembers;
    }

    public void DisbandParty()
    {
        partyMembers.Clear();
        Debug.Log("Party disbanded.");
    }
}