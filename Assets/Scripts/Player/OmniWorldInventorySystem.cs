using UnityEngine;
using System.Collections.Generic;

public class OmniWorldInventorySystem : MonoBehaviour
{
    public List<string> inventory =
        new List<string>();

    public int maxItems = 100;

    void Start()
    {
        InitializeInventory();
    }

    void InitializeInventory()
    {
        inventory.Add("Starter Tool");
        inventory.Add("AI Crystal");

        Debug.Log(
            "Inventory System Activated"
        );
    }

    public void AddItem(string itemName)
    {
        if (inventory.Count < maxItems)
        {
            inventory.Add(itemName);

            Debug.Log(
                "Item Added: " +
                itemName
            );
        }
    }

    public void RemoveItem(string itemName)
    {
        if (inventory.Contains(itemName))
        {
            inventory.Remove(itemName);

            Debug.Log(
                "Item Removed: " +
                itemName
            );
        }
    }

    public bool HasItem(string itemName)
    {
        return inventory.Contains(itemName);
    }

    public int GetItemCount()
    {
        return inventory.Count;
    }
}