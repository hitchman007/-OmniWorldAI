using UnityEngine;

public class OmniNetworkPlayer : MonoBehaviour
{
    public string playerId;
    public string playerName = "Explorer";
    public bool isLocalPlayer;

    [Header("Player Stats")]
    public int level = 1;
    public int coins = 0;

    private void Start()
    {
        if (isLocalPlayer)
        {
            Debug.Log("Local player connected: " + playerName);
        }
    }

    public void SetPlayerInfo(string id, string newName)
    {
        playerId = id;
        playerName = newName;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log(playerName + " now has " + coins + " coins.");
    }

    public void AddLevel()
    {
        level++;
        Debug.Log(playerName + " reached level " + level);
    }

    public void DisconnectPlayer()
    {
        Debug.Log(playerName + " disconnected.");
        Destroy(gameObject);
    }
}