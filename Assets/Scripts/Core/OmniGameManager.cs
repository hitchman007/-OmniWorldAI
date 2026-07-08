using UnityEngine;

public class OmniGameManager : MonoBehaviour
{
    public static OmniGameManager Instance;

    private bool gameStarted;

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

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        gameStarted = true;

        Debug.Log("OmniWorld AI Initialized");
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }
}