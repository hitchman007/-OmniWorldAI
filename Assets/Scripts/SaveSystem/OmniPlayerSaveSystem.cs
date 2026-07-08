using UnityEngine;

public class OmniPlayerSaveSystem : MonoBehaviour
{
    private const string PlayerNameKey = "OmniPlayerName";
    private const string PlayerLevelKey = "OmniPlayerLevel";
    private const string PlayerCoinsKey = "OmniPlayerCoins";

    public void SavePlayer(string playerName, int level, int coins)
    {
        PlayerPrefs.SetString(PlayerNameKey, playerName);
        PlayerPrefs.SetInt(PlayerLevelKey, level);
        PlayerPrefs.SetInt(PlayerCoinsKey, coins);
        PlayerPrefs.Save();

        Debug.Log("Player data saved.");
    }

    public string LoadPlayerName()
    {
        return PlayerPrefs.GetString(PlayerNameKey, "Explorer");
    }

    public int LoadPlayerLevel()
    {
        return PlayerPrefs.GetInt(PlayerLevelKey, 1);
    }

    public int LoadPlayerCoins()
    {
        return PlayerPrefs.GetInt(PlayerCoinsKey, 0);
    }

    public void DeletePlayerData()
    {
        PlayerPrefs.DeleteKey(PlayerNameKey);
        PlayerPrefs.DeleteKey(PlayerLevelKey);
        PlayerPrefs.DeleteKey(PlayerCoinsKey);
        PlayerPrefs.Save();

        Debug.Log("Player data deleted.");
    }
}