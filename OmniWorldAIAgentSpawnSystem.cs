using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentSpawnSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentSpawnSystem Instance;

        private List<string> spawnedAgents =
            new List<string>();


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


        public void SpawnAgent(
            string agentID)
        {
            if (!spawnedAgents.Contains(agentID))
            {
                spawnedAgents.Add(agentID);

                Debug.Log(
                    "AI Agent Spawned: " +
                    agentID
                );
            }
        }


        public void DespawnAgent(
            string agentID)
        {
            if (spawnedAgents.Contains(agentID))
            {
                spawnedAgents.Remove(agentID);
            }
        }


        public bool IsSpawned(
            string agentID)
        {
            return spawnedAgents.Contains(agentID);
        }


        public List<string> GetSpawnedAgents()
        {
            return spawnedAgents;
        }


        public int GetSpawnCount()
        {
            return spawnedAgents.Count;
        }
    }
}