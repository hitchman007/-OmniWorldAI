using UnityEngine;
using System.Collections.Generic;

public class OmniWorldInventorySystem : MonoBehaviour
{
    public List<string> inventoryItems = new List<string>();

    void Start()
    {
        AddStarterItems();
    }

    void AddStarterItems()
    {
        inventoryItems.Add("AI Crystal");
        inventoryItems.Add("World Builder Tool");
        inventoryItems.Add("Energy Core");

        Debug.Log("Inventory System Ready");
    }

    public void AddItem(string itemName)
    {
        inventoryItems.Add(itemName);

        Debug.Log("Item Added: " + itemName);
    }

    public void RemoveItem(string itemName)
    {
        if (inventoryItems.Contains(itemName))
        {
            inventoryItems.Remove(itemName);

            Debug.Log("Item Removed: " + itemName);
        }
    }

    public bool HasItem(string itemName)
    {
        return inventoryItems.Contains(itemName);
    }

    public int GetInventorySize()
    {
        return inventoryItems.Count;
    }
}