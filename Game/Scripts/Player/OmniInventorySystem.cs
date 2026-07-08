using System.Collections.Generic;
using UnityEngine;

public class OmniInventorySystem : MonoBehaviour
{
    public List<string> items =
    new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);

        Debug.Log(
        "Objeto añadido: " + item
        );
    }

    public void RemoveItem(string item)
    {
        items.Remove(item);

        Debug.Log(
        "Objeto eliminado: " + item
        );
    }
}