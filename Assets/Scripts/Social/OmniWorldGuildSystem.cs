using System.Collections.Generic;
using UnityEngine;

public class OmniWorldGuildSystem : MonoBehaviour
{
    [Header("Guild System")]
    public string guildName = "OmniWorld Guild";
    public string guildLeader = "";
    public int maxGuildMembers = 50;

    public List<string> guildMembers = new List<string>();

    public int MemberCount
    {
        get { return guildMembers.Count; }
    }

    private void Start()
    {
        Debug.Log("OmniWorld Guild System initialized.");
    }

    public bool CreateGuild(string newGuildName, string leaderName)
    {
        if (string.IsNullOrEmpty(newGuildName) || string.IsNullOrEmpty(leaderName))
        {
            Debug.LogWarning("Guild creation failed: missing name or leader.");
            return false;
        }

        guildName = newGuildName;
        guildLeader = leaderName;
        guildMembers.Clear();
        guildMembers.Add(leaderName);

        Debug.Log("Guild created: " + guildName);
        return true;
    }

    public bool AddMember(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            return false;
        }

        if (guildMembers.Count >= maxGuildMembers)
        {
            Debug.LogWarning("Guild is full.");
            return false;
        }

        if (guildMembers.Contains(playerName))
        {
            return false;
        }

        guildMembers.Add(playerName);
        Debug.Log(playerName + " joined guild: " + guildName);
        return true;
    }

    public void RemoveMember(string playerName)
    {
        if (playerName == guildLeader)
        {
            Debug.LogWarning("Guild leader cannot be removed directly.");
            return;
        }

        if (guildMembers.Contains(playerName))
        {
            guildMembers.Remove(playerName);
            Debug.Log(playerName + " left the guild.");
        }
    }

    public bool IsMember(string playerName)
    {
        return guildMembers.Contains(playerName);
    }

    public void DisbandGuild()
    {
        guildMembers.Clear();
        guildLeader = "";
        guildName = "No Guild";

        Debug.Log("Guild disbanded.");
    }
}