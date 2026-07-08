using UnityEngine;

public class OmniWorldAIBehaviorSystem : MonoBehaviour
{
    public string aiName = "Omni AI Entity";
    public float intelligenceLevel = 100f;

    public enum AIState
    {
        Idle,
        Exploring,
        Building,
        Protecting,
        Learning
    }

    public AIState currentState = AIState.Idle;

    void Start()
    {
        InitializeAI();
    }

    void InitializeAI()
    {
        Debug.Log(aiName + " Initialized");
        Debug.Log("Intelligence Level: " + intelligenceLevel);
    }

    public void ChangeState(AIState newState)
    {
        currentState = newState;

        Debug.Log(
            aiName + " State Changed: " + currentState
        );
    }

    public void Learn()
    {
        intelligenceLevel += 1f;

        currentState = AIState.Learning;

        Debug.Log(
            aiName + " Learning. Intelligence: " +
            intelligenceLevel
        );
    }

    public string GetCurrentState()
    {
        return currentState.ToString();
    }
}