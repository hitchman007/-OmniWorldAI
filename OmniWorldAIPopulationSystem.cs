using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIPopulationSystem : MonoBehaviour
    {
        public static OmniWorldAIPopulationSystem Instance;

        private Dictionary<string, int> worldPopulations =
            new Dictionary<string, int>();


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


        public void CreatePopulation(
            string worldID,
            int amount)
        {
            if (worldPopulations.ContainsKey(worldID))
            {
                worldPopulations[worldID] = amount;
            }
            else
            {
                worldPopulations.Add(
                    worldID,
                    amount
                );
            }
        }


        public void IncreasePopulation(
            string worldID,
            int amount)
        {
            if (worldPopulations.ContainsKey(worldID))
            {
                worldPopulations[worldID] += amount;
            }
        }


        public void DecreasePopulation(
            string worldID,
            int amount)
        {
            if (worldPopulations.ContainsKey(worldID))
            {
                worldPopulations[worldID] -= amount;

                if (worldPopulations[worldID] < 0)
                {
                    worldPopulations[worldID] = 0;
                }
            }
        }


        public int GetPopulation(
            string worldID)
        {
            if (worldPopulations.ContainsKey(worldID))
            {
                return worldPopulations[worldID];
            }

            return 0;
        }


        public void RemoveWorld(
            string worldID)
        {
            if (worldPopulations.ContainsKey(worldID))
            {
                worldPopulations.Remove(worldID);
            }
        }
    }
}