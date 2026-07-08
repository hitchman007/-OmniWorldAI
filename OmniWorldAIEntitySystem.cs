using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIEntitySystem : MonoBehaviour
    {
        public static OmniWorldAIEntitySystem Instance;

        private Dictionary<string, string> entities =
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


        public void CreateEntity(
            string entityID,
            string entityType)
        {
            if (!entities.ContainsKey(entityID))
            {
                entities.Add(
                    entityID,
                    entityType
                );

                Debug.Log(
                    "AI Entity Created: " + entityID
                );
            }
        }


        public string GetEntityType(
            string entityID)
        {
            if (entities.ContainsKey(entityID))
            {
                return entities[entityID];
            }

            return "Unknown";
        }


        public void RemoveEntity(
            string entityID)
        {
            if (entities.ContainsKey(entityID))
            {
                entities.Remove(entityID);
            }
        }


        public bool EntityExists(
            string entityID)
        {
            return entities.ContainsKey(entityID);
        }


        public int GetEntityCount()
        {
            return entities.Count;
        }
    }
}