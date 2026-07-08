using UnityEngine;

public class OmniWorldLevelSystem : MonoBehaviour
{
    public int playerLevel = 1;
    public int experience = 0;
    public int experienceToNextLevel = 100;

    void Start()
    {
        Debug.Log("Level System Activated");
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        Debug.Log("Experience Added: " + amount);

        CheckLevelUp();
    }

    void CheckLevelUp()
    {
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        playerLevel++;

        experience = 0;
        experienceToNextLevel += 100;

        Debug.Log(
            "Level Up! Current Level: " + playerLevel
        );
    }

    public int GetLevel()
    {
        return playerLevel;
    }

    public int GetExperience()
    {
        return experience;
    }
}