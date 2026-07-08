using UnityEngine;

public class OmniWorldPlayerProfileSystem : MonoBehaviour
{
    public string playerName = "Creator";
    public string playerID = "OWAI_001";

    public int worldsCreated = 0;
    public int discoveries = 0;

    void Start()
    {
        InitializeProfile();
    }

    void InitializeProfile()
    {
        Debug.Log("Player Profile Loaded");
        Debug.Log("Player: " + playerName);
        Debug.Log("ID: " + playerID);
    }

    public void CreateWorld()
    {
        worldsCreated++;

        Debug.Log(
            "Worlds Created: " + worldsCreated
        );
    }

    public void AddDiscovery()
    {
        discoveries++;

        Debug.Log(
            "Discoveries: " + discoveries
        );
    }

    public void UpdatePlayerName(string newName)
    {
        playerName = newName;

        Debug.Log(
            "Player Name Updated: " + playerName
        );
    }

    public string GetProfileInfo()
    {
        return playerName + " | Worlds: " +
            worldsCreated +
            " | Discoveries: " +
            discoveries;
    }
}