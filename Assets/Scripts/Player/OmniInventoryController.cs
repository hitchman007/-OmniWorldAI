using System.Collections.Generic;
using UnityEngine;

public class OmniInventoryController : MonoBehaviour
{
    public static OmniInventoryController Instance;

    private List<string> items = new List<string>();

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

    public void AddItem(string itemName)
    {
        items.Add(itemName);

        Debug.Log(
            "Item added: " + itemName
        );
    }

    public void RemoveItem(string itemName)
    {
        items.Remove(itemName);

        Debug.Log(
            "Item removed: " + itemName
        );
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}