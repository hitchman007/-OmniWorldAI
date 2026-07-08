using UnityEngine;

[System.Serializable]
public class OmniWorldPlayerProfile
{
    public string playerName;
    public string playerId;
    public int level;
    public int experience;
    public string statusMessage;

    public OmniWorldPlayerProfile(
        string name,
        string id,
        int playerLevel,
        int playerExperience
    )
    {
        playerName = name;
        playerId = id;
        level = playerLevel;
        experience = playerExperience;
        statusMessage = "Exploring OmniWorld AI";
    }
}

public class OmniWorldPlayerProfileSystem : MonoBehaviour
{
    [Header("Player Profile")]
    public OmniWorldPlayerProfile currentProfile;

    public int experiencePerLevel = 100;

    private void Start()
    {
        if (currentProfile == null)
        {
            currentProfile = new OmniWorldPlayerProfile(
                "Player",
                System.Guid.NewGuid().ToString(),
                1,
                0
            );
        }

        Debug.Log("OmniWorld Player Profile System initialized.");
    }

    public void SetPlayerName(string newName)
    {
        if (string.IsNullOrEmpty(newName))
        {
            return;
        }

        currentProfile.playerName = newName;
        Debug.Log("Player name updated: " + newName);
    }

    public void SetStatusMessage(string newStatus)
    {
        if (string.IsNullOrEmpty(newStatus))
        {
            return;
        }

        currentProfile.statusMessage = newStatus;
    }

    public void AddExperience(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        currentProfile.experience += amount;

        while (currentProfile.experience >= experiencePerLevel)
        {
            currentProfile.experience -= experiencePerLevel;
            currentProfile.level++;

            Debug.Log("Level up! Current level: " + currentProfile.level);
        }
    }

    public string GetProfileSummary()
    {
        return currentProfile.playerName +
               " | Level " + currentProfile.level +
               " | XP " + currentProfile.experience;
    }
}