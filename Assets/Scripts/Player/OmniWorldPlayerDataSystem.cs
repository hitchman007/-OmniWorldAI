using UnityEngine;

public class OmniWorldPlayerDataSystem : MonoBehaviour
{
    public string playerName = "Creator";

    public int level = 1;
    public int experience = 0;

    public int worldsCreated = 0;

    void Start()
    {
        InitializePlayerData();
    }

    void InitializePlayerData()
    {
        Debug.Log(
            "Player Data System Activated"
        );

        Debug.Log(
            "Player: " + playerName
        );
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        CheckLevel();
    }

    void CheckLevel()
    {
        if (experience >= 100)
        {
            level++;
            experience = 0;

            Debug.Log(
                "Player Level Up: " +
                level
            );
        }
    }

    public void CreateWorld()
    {
        worldsCreated++;

        Debug.Log(
            "Worlds Created: " +
            worldsCreated
        );
    }

    public string GetPlayerInfo()
    {
        return playerName +
            " Level: " +
            level;
    }
}