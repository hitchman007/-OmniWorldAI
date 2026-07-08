using UnityEngine;
using System.Collections.Generic;

public class OmniWorldAchievementSystem : MonoBehaviour
{
    public List<string> unlockedAchievements = new List<string>();

    void Start()
    {
        Debug.Log("Achievement System Ready");
    }

    public void UnlockAchievement(string achievementName)
    {
        if (!unlockedAchievements.Contains(achievementName))
        {
            unlockedAchievements.Add(achievementName);

            Debug.Log("Achievement Unlocked: " + achievementName);
        }
    }

    public bool HasAchievement(string achievementName)
    {
        return unlockedAchievements.Contains(achievementName);
    }

    public int GetAchievementCount()
    {
        return unlockedAchievements.Count;
    }
}