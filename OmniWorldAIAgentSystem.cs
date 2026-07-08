using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentSystem Instance;

        private Dictionary<string, string> agents =
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


        public void CreateAgent(
            string agentID,
            string role)
        {
            if (!agents.ContainsKey(agentID))
            {
                agents.Add(
                    agentID,
                    role
                );

                Debug.Log(
                    "AI Agent Created: " + agentID
                );
            }
        }


        public string GetAgentRole(
            string agentID)
        {
            if (agents.ContainsKey(agentID))
            {
                return agents[agentID];
            }

            return "Unknown";
        }


        public void RemoveAgent(
            string agentID)
        {
            if (agents.ContainsKey(agentID))
            {
                agents.Remove(agentID);
            }
        }


        public int GetAgentCount()
        {
            return agents.Count;
        }
    }
}