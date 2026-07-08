using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIDynamicWorldSystem : MonoBehaviour
    {
        public static OmniWorldAIDynamicWorldSystem Instance;

        private Dictionary<string, float> worldValues =
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


        public void SetWorldValue(
            string key,
            float value)
        {
            if (worldValues.ContainsKey(key))
            {
                worldValues[key] = value;
            }
            else
            {
                worldValues.Add(key, value);
            }
        }


        public float GetWorldValue(
            string key)
        {
            if (worldValues.ContainsKey(key))
            {
                return worldValues[key];
            }

            return 0f;
        }


        public void IncreaseWorldValue(
            string key,
            float amount)
        {
            float current =
                GetWorldValue(key);

            SetWorldValue(
                key,
                current + amount
            );
        }


        public void RemoveValue(
            string key)
        {
            if (worldValues.ContainsKey(key))
            {
                worldValues.Remove(key);
            }
        }


        public void ClearWorldValues()
        {
            worldValues.Clear();
        }
    }
}