using UnityEngine;

public class OmniQuestSystem : MonoBehaviour
{
    public int completedQuests;

    public void StartQuest(string questName)
    {
        Debug.Log(
        "Misión iniciada: " + questName
        );
    }

    public void CompleteQuest(string questName)
    {
        completedQuests++;

        Debug.Log(
        "Misión completada: " + questName
        );
    }
}