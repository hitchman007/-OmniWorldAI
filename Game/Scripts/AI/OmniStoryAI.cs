using UnityEngine;

public class OmniStoryAI : MonoBehaviour
{
    public string currentStory;

    public void GenerateStory(string idea)
    {
        currentStory = idea;

        Debug.Log(
        "Historia creada: " + currentStory
        );
    }

    public void CompleteMission(string mission)
    {
        Debug.Log(
        "Misión completada: " + mission
        );
    }
}