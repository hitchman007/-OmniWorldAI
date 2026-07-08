using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIBehaviorTreeSystem : MonoBehaviour
    {
        public static OmniWorldAIBehaviorTreeSystem Instance;

        private Dictionary<string, string> behaviors =
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


        public void CreateBehavior(
            string entityID,
            string behavior)
        {
            if (behaviors.ContainsKey(entityID))
            {
                behaviors[entityID] = behavior;
            }
            else
            {
                behaviors.Add(
                    entityID,
                    behavior
                );
            }
        }


        public string GetBehavior(
            string entityID)
        {
            if (behaviors.ContainsKey(entityID))
            {
                return behaviors[entityID];
            }

            return "Idle";
        }


        public void UpdateBehavior(
            string entityID,
            string newBehavior)
        {
            if (behaviors.ContainsKey(entityID))
            {
                behaviors[entityID] = newBehavior;
            }
        }


        public void RemoveBehavior(
            string entityID)
        {
            if (behaviors.ContainsKey(entityID))
            {
                behaviors.Remove(entityID);
            }
        }


        public int GetBehaviorCount()
        {
            return behaviors.Count;
        }
    }
}