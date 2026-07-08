using System.Collections.Generic;
using UnityEngine;

public class OmniQuestSystem : MonoBehaviour
{
    public static OmniQuestSystem Instance;

    private List<string> completedQuests = new List<string>();

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

    public void CompleteQuest(string questName)
    {
        completedQuests.Add(questName);

        Debug.Log(
            "Quest completed: " + questName
        );
    }

    public bool HasCompletedQuest(string questName)
    {
        return completedQuests.Contains(questName);
    }
}