using UnityEngine;

public class OmniWorldEconomySystem : MonoBehaviour
{
    public int playerCredits = 1000;
    public int worldTreasury = 50000;

    void Start()
    {
        Debug.Log("Economy System Activated");
    }

    public void AddCredits(int amount)
    {
        playerCredits += amount;

        Debug.Log("Credits Added: " + amount);
    }

    public bool SpendCredits(int amount)
    {
        if (playerCredits >= amount)
        {
            playerCredits -= amount;

            Debug.Log("Credits Spent: " + amount);
            return true;
        }

        Debug.Log("Not Enough Credits");
        return false;
    }

    public void TransferToWorld(int amount)
    {
        if (playerCredits >= amount)
        {
            playerCredits -= amount;
            worldTreasury += amount;

            Debug.Log("Transferred To World Treasury: " + amount);
        }
    }

    public int GetPlayerCredits()
    {
        return playerCredits;
    }
}