using UnityEngine;
using System.Collections.Generic;

public class OmniWorldLearningAISystem : MonoBehaviour
{
    public int learningPoints = 0;

    public List<string> learnedAbilities =
        new List<string>();

    void Start()
    {
        InitializeLearningAI();
    }

    void InitializeLearningAI()
    {
        Debug.Log("Learning AI System Activated");
    }

    public void LearnAbility(string ability)
    {
        if (!learnedAbilities.Contains(ability))
        {
            learnedAbilities.Add(ability);

            learningPoints += 10;

            Debug.Log(
                "AI Learned: " +
                ability
            );
        }
    }

    public void AddLearningExperience(int points)
    {
        learningPoints += points;

        Debug.Log(
            "Learning Points: " +
            learningPoints
        );
    }

    public bool HasAbility(string ability)
    {
        return learnedAbilities.Contains(ability);
    }

    public int GetLearningLevel()
    {
        return learningPoints / 100;
    }
}