using System.Collections.Generic;
using UnityEngine;

public class OmniAchievementSystem : MonoBehaviour
{
    public static OmniAchievementSystem Instance;

    private List<string> achievements = new List<string>();

    private void Awake()
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

    public void UnlockAchievement(string achievement)
    {
        achievements.Add(achievement);

        Debug.Log(
            "Achievement unlocked: " + achievement
        );
    }

    public bool HasAchievement(string achievement)
    {
        return achievements.Contains(achievement);
    }
}