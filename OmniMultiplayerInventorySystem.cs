using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerInventorySystem : MonoBehaviour
    {
        public static OmniMultiplayerInventorySystem Instance;

        private Dictionary<string, List<string>> inventories =
            new Dictionary<string, List<string>>();


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


        public void CreateInventory(string playerID)
        {
            if (!inventories.ContainsKey(playerID))
            {
                inventories.Add(
                    playerID,
                    new List<string>()
                );
            }
        }


        public void AddItem(
            string playerID,
            string item)
        {
            if (!inventories.ContainsKey(playerID))
            {
                CreateInventory(playerID);
            }

            if (!inventories[playerID].Contains(item))
            {
                inventories[playerID].Add(item);
            }
        }


        public void RemoveItem(
            string playerID,
            string item)
        {
            if (inventories.ContainsKey(playerID))
            {
                inventories[playerID].Remove(item);
            }
        }


        public List<string> GetInventory(
            string playerID)
        {
            if (inventories.ContainsKey(playerID))
            {
                return inventories[playerID];
            }

            return new List<string>();
        }


        public bool HasItem(
            string playerID,
            string item)
        {
            if (inventories.ContainsKey(playerID))
            {
                return inventories[playerID].Contains(item);
            }

            return false;
        }
    }
}