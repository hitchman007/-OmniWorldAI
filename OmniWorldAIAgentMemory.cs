using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentMemory : MonoBehaviour
    {
        public static OmniWorldAIAgentMemory Instance;

        private Dictionary<string, List<string>> memories =
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


        public void RegisterAgent(
            string agentID)
        {
            if (!memories.ContainsKey(agentID))
            {
                memories.Add(
                    agentID,
                    new List<string>()
                );
            }
        }


        public void AddMemory(
            string agentID,
            string memory)
        {
            if (!memories.ContainsKey(agentID))
            {
                RegisterAgent(agentID);
            }

            memories[agentID].Add(memory);
        }


        public List<string> GetMemories(
            string agentID)
        {
            if (memories.ContainsKey(agentID))
            {
                return memories[agentID];
            }

            return new List<string>();
        }


        public void RemoveMemory(
            string agentID,
            string memory)
        {
            if (memories.ContainsKey(agentID))
            {
                memories[agentID].Remove(memory);
            }
        }


        public void ClearAgentMemory(
            string agentID)
        {
            if (memories.ContainsKey(agentID))
            {
                memories[agentID].Clear();
            }
        }
    }
}