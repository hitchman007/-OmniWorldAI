using UnityEngine;
using System.Collections.Generic;

public class OmniWorldCraftingSystem : MonoBehaviour
{
    public List<string> craftedItems = new List<string>();

    void Start()
    {
        Debug.Log("Crafting System Activated");
    }

    public void CraftItem(string itemName)
    {
        if (!craftedItems.Contains(itemName))
        {
            craftedItems.Add(itemName);

            Debug.Log("Item Crafted: " + itemName);
        }
    }

    public bool HasCrafted(string itemName)
    {
        return craftedItems.Contains(itemName);
    }

    public void RemoveCraftedItem(string itemName)
    {
        if (craftedItems.Contains(itemName))
        {
            craftedItems.Remove(itemName);

            Debug.Log("Crafted Item Removed: " + itemName);
        }
    }

    public int GetCraftedItemCount()
    {
        return craftedItems.Count;
    }
}