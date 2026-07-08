using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OmniWorldPlayerPresence
{
    public string playerName;
    public bool isOnline;
    public string currentWorld;
    public string lastStatus;

    public OmniWorldPlayerPresence(
        string name,
        bool online,
        string world
    )
    {
        playerName = name;
        isOnline = online;
        currentWorld = world;
        lastStatus = online ? "Online" : "Offline";
    }
}

public class OmniWorldPlayerPresenceSystem : MonoBehaviour
{
    [Header("Player Presence System")]
    public List<OmniWorldPlayerPresence> playerPresences =
        new List<OmniWorldPlayerPresence>();

    private void Start()
    {
        Debug.Log("OmniWorld Player Presence System initialized.");
    }

    public void SetPlayerOnline(string playerName, string worldName)
    {
        OmniWorldPlayerPresence presence = GetPresence(playerName);

        if (presence == null)
        {
            presence = new OmniWorldPlayerPresence(
                playerName,
                true,
                worldName
            );

            playerPresences.Add(presence);
        }
        else
        {
            presence.isOnline = true;
            presence.currentWorld = worldName;
            presence.lastStatus = "Online";
        }

        Debug.Log(playerName + " is now online.");
    }

    public void SetPlayerOffline(string playerName)
    {
        OmniWorldPlayerPresence presence = GetPresence(playerName);

        if (presence != null)
        {
            presence.isOnline = false;
            presence.lastStatus = "Offline";

            Debug.Log(playerName + " is now offline.");
        }
    }

    public void UpdatePlayerWorld(string playerName, string worldName)
    {
        OmniWorldPlayerPresence presence = GetPresence(playerName);

        if (presence != null && presence.isOnline)
        {
            presence.currentWorld = worldName;
            Debug.Log(playerName + " moved to world: " + worldName);
        }
    }

    public bool IsPlayerOnline(string playerName)
    {
        OmniWorldPlayerPresence presence = GetPresence(playerName);

        return presence != null && presence.isOnline;
    }

    private OmniWorldPlayerPresence GetPresence(string playerName)
    {
        return playerPresences.Find(
            presence => presence.playerName == playerName
        );
    }
}