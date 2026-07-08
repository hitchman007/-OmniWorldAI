using UnityEngine;
using System.Collections.Generic;

public class OmniMultiplayerWorldSystem : MonoBehaviour
{
    public static OmniMultiplayerWorldSystem Instance;

    private List<string> connectedPlayers = new List<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(string playerID)
    {
        if (!connectedPlayers.Contains(playerID))
        {
            connectedPlayers.Add(playerID);
            Debug.Log("Player joined: " + playerID);
        }
    }

    public void RemovePlayer(string playerID)
    {
        if (connectedPlayers.Contains(playerID))
        {
            connectedPlayers.Remove(playerID);
            Debug.Log("Player left: " + playerID);
        }
    }

    public int GetPlayerCount()
    {
        return connectedPlayers.Count;
    }
}