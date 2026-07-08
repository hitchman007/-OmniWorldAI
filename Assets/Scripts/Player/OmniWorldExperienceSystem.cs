using UnityEngine;

public class OmniWorldExperienceSystem : MonoBehaviour
{
    public int experience = 0;
    public int level = 1;

    public int experienceToNextLevel = 100;

    void Start()
    {
        Debug.Log(
            "Experience System Activated"
        );
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        Debug.Log(
            "Experience Added: " +
            amount
        );

        CheckLevelUp();
    }

    void CheckLevelUp()
    {
        if (experience >= experienceToNextLevel)
        {
            level++;

            experience = 0;

            experienceToNextLevel += 100;

            Debug.Log(
                "Level Up: " +
                level
            );
        }
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetExperience()
    {
        return experience;
    }
}