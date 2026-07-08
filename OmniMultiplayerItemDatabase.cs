using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerItemDatabase : MonoBehaviour
    {
        public static OmniMultiplayerItemDatabase Instance;

        private Dictionary<string, string> items =
            new Dictionary<string, string>();


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


        public void RegisterItem(
            string itemID,
            string itemName)
        {
            if (!items.ContainsKey(itemID))
            {
                items.Add(itemID, itemName);
            }
        }


        public string GetItemName(
            string itemID)
        {
            if (items.ContainsKey(itemID))
            {
                return items[itemID];
            }

            return "Unknown Item";
        }


        public bool ItemExists(
            string itemID)
        {
            return items.ContainsKey(itemID);
        }


        public void RemoveItem(
            string itemID)
        {
            if (items.ContainsKey(itemID))
            {
                items.Remove(itemID);
            }
        }


        public int GetItemCount()
        {
            return items.Count;
        }
    }
}