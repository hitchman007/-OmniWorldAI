using UnityEngine;
using System.Collections.Generic;

public class OmniWorldAchievementDatabase : MonoBehaviour
{
    public Dictionary<string, bool> achievements =
        new Dictionary<string, bool>();

    void Start()
    {
        InitializeAchievements();
    }

    void InitializeAchievements()
    {
        achievements.Add("First World Created", false);
        achievements.Add("First AI Activated", false);
        achievements.Add("Multiverse Explorer", false);

        Debug.Log("Achievement Database Activated");
    }

    public void UnlockAchievement(string achievementName)
    {
        if (achievements.ContainsKey(achievementName))
        {
            achievements[achievementName] = true;

            Debug.Log(
                "Achievement Unlocked: " +
                achievementName
            );
        }
    }

    public bool IsUnlocked(string achievementName)
    {
        if (achievements.ContainsKey(achievementName))
        {
            return achievements[achievementName];
        }

        return false;
    }

    public int GetAchievementTotal()
    {
        return achievements.Count;
    }

    public int GetUnlockedCount()
    {
        int count = 0;

        foreach (bool unlocked in achievements.Values)
        {
            if (unlocked)
            {
                count++;
            }
        }

        return count;
    }
}