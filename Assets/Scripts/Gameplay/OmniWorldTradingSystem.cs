using UnityEngine;
using System.Collections.Generic;

public class OmniWorldTradingSystem : MonoBehaviour
{
    public Dictionary<string, int> marketItems =
        new Dictionary<string, int>();

    void Start()
    {
        InitializeMarket();
    }

    void InitializeMarket()
    {
        marketItems.Add("AI Crystal", 100);
        marketItems.Add("Energy Core", 250);
        marketItems.Add("Quantum Metal", 500);

        Debug.Log("Trading System Activated");
    }

    public void BuyItem(string itemName, int credits)
    {
        if (marketItems.ContainsKey(itemName))
        {
            if (credits >= marketItems[itemName])
            {
                Debug.Log("Purchased: " + itemName);
            }
            else
            {
                Debug.Log("Not Enough Credits");
            }
        }
    }

    public void AddMarketItem(string itemName, int price)
    {
        if (!marketItems.ContainsKey(itemName))
        {
            marketItems.Add(itemName, price);

            Debug.Log("Market Item Added: " + itemName);
        }
    }

    public int GetItemPrice(string itemName)
    {
        if (marketItems.ContainsKey(itemName))
        {
            return marketItems[itemName];
        }

        return 0;
    }

    public int GetMarketSize()
    {
        return marketItems.Count;
    }
}