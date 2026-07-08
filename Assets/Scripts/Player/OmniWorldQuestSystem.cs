using UnityEngine;
using System.Collections.Generic;

public class OmniWorldQuestSystem : MonoBehaviour
{
    public List<string> activeQuests =
        new List<string>();

    public List<string> completedQuests =
        new List<string>();

    void Start()
    {
        InitializeQuests();
    }

    void InitializeQuests()
    {
        activeQuests.Add("Create Your First World");
        activeQuests.Add("Explore Unknown Universe");

        Debug.Log(
            "Quest System Activated"
        );
    }

    public void CompleteQuest(string questName)
    {
        if (activeQuests.Contains(questName))
        {
            activeQuests.Remove(questName);

            completedQuests.Add(questName);

            Debug.Log(
                "Quest Completed: " +
                questName
            );
        }
    }

    public void AddQuest(string questName)
    {
        if (!activeQuests.Contains(questName))
        {
            activeQuests.Add(questName);

            Debug.Log(
                "Quest Added: " +
                questName
            );
        }
    }

    public bool IsCompleted(string questName)
    {
        return completedQuests.Contains(questName);
    }

    public int GetCompletedQuestCount()
    {
        return completedQuests.Count;
    }
}