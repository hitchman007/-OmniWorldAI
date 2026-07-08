using UnityEngine;

public class OmniSaveSystem : MonoBehaviour
{
    public static OmniSaveSystem Instance;

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

    public void SaveGame()
    {
        Debug.Log(
            "Game saved"
        );
    }

    public void LoadGame()
    {
        Debug.Log(
            "Game loaded"
        );
    }
}