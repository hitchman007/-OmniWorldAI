using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIResourceSystem : MonoBehaviour
    {
        public static OmniWorldAIResourceSystem Instance;

        private Dictionary<string, float> resources =
            new Dictionary<string, float>();


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


        public void CreateResource(
            string resourceID,
            float amount)
        {
            if (resources.ContainsKey(resourceID))
            {
                resources[resourceID] = amount;
            }
            else
            {
                resources.Add(
                    resourceID,
                    amount
                );
            }
        }


        public void AddResource(
            string resourceID,
            float amount)
        {
            if (resources.ContainsKey(resourceID))
            {
                resources[resourceID] += amount;
            }
        }


        public bool ConsumeResource(
            string resourceID,
            float amount)
        {
            if (resources.ContainsKey(resourceID))
            {
                if (resources[resourceID] >= amount)
                {
                    resources[resourceID] -= amount;

                    return true;
                }
            }

            return false;
        }


        public float GetResource(
            string resourceID)
        {
            if (resources.ContainsKey(resourceID))
            {
                return resources[resourceID];
            }

            return 0f;
        }


        public void RemoveResource(
            string resourceID)
        {
            if (resources.ContainsKey(resourceID))
            {
                resources.Remove(resourceID);
            }
        }
    }
}