using UnityEngine;
using System.Collections.Generic;

public class OmniWorldAchievementTracker : MonoBehaviour
{
    public List<string> achievements = new List<string>();

    public int totalPoints = 0;

    void Start()
    {
        Debug.Log("Achievement Tracker Activated");
    }

    public void UnlockAchievement(string achievementName, int points)
    {
        if (!achievements.Contains(achievementName))
        {
            achievements.Add(achievementName);

            totalPoints += points;

            Debug.Log(
                "Achievement Unlocked: " +
                achievementName +
                " Points: " +
                points
            );
        }
    }

    public bool HasAchievement(string achievementName)
    {
        return achievements.Contains(achievementName);
    }

    public int GetAchievementPoints()
    {
        return totalPoints;
    }

    public int GetAchievementCount()
    {
        return achievements.Count;
    }
}