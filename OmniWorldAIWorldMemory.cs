using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIWorldMemory : MonoBehaviour
    {
        public static OmniWorldAIWorldMemory Instance;

        private Dictionary<string, string> worldMemory =
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


        public void StoreMemory(
            string key,
            string value)
        {
            if (worldMemory.ContainsKey(key))
            {
                worldMemory[key] = value;
            }
            else
            {
                worldMemory.Add(key, value);
            }
        }


        public string RetrieveMemory(
            string key)
        {
            if (worldMemory.ContainsKey(key))
            {
                return worldMemory[key];
            }

            return "";
        }


        public bool HasMemory(
            string key)
        {
            return worldMemory.ContainsKey(key);
        }


        public void RemoveMemory(
            string key)
        {
            if (worldMemory.ContainsKey(key))
            {
                worldMemory.Remove(key);
            }
        }


        public void ClearMemory()
        {
            worldMemory.Clear();
        }
    }
}