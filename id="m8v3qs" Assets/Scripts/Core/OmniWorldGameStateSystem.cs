using UnityEngine;

public class OmniWorldGameStateSystem : MonoBehaviour
{
    public enum GameState
    {
        Loading,
        MainMenu,
        CreatingWorld,
        Exploring,
        Multiplayer,
        Paused
    }

    public GameState currentState = GameState.Loading;

    void Start()
    {
        SetState(GameState.MainMenu);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        Debug.Log(
            "Game State Changed: " +
            currentState
        );
    }

    public string GetCurrentState()
    {
        return currentState.ToString();
    }

    public bool IsPlaying()
    {
        return currentState == GameState.Exploring ||
               currentState == GameState.Multiplayer;
    }
}