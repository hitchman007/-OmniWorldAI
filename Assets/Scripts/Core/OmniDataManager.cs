using UnityEngine;

public class OmniDataManager : MonoBehaviour
{
    public static OmniDataManager Instance;

    private string playerName;
    private int playerLevel;

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

    public void SavePlayerData(string name, int level)
    {
        playerName = name;
        playerLevel = level;

        Debug.Log("Player data saved");
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }
}