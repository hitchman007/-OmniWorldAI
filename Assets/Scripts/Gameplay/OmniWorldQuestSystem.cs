using UnityEngine;
using System.Collections.Generic;

public class OmniWorldQuestSystem : MonoBehaviour
{
    public List<string> activeQuests = new List<string>();

    void Start()
    {
        CreateDefaultQuests();
    }

    void CreateDefaultQuests()
    {
        activeQuests.Add("Explore the AI World");
        activeQuests.Add("Discover New Realms");
        activeQuests.Add("Build Your Civilization");

        Debug.Log("OmniWorld Quests Loaded");
    }

    public void AddQuest(string questName)
    {
        activeQuests.Add(questName);

        Debug.Log("New Quest Added: " + questName);
    }

    public void CompleteQuest(string questName)
    {
        if (activeQuests.Contains(questName))
        {
            activeQuests.Remove(questName);

            Debug.Log("Quest Completed: " + questName);
        }
    }

    public int GetQuestCount()
    {
        return activeQuests.Count;
    }
}