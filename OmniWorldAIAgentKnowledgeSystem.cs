using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentKnowledgeSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentKnowledgeSystem Instance;

        private Dictionary<string, List<string>> knowledge =
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
            if (!knowledge.ContainsKey(agentID))
            {
                knowledge.Add(
                    agentID,
                    new List<string>()
                );
            }
        }


        public void AddKnowledge(
            string agentID,
            string information)
        {
            if (!knowledge.ContainsKey(agentID))
            {
                RegisterAgent(agentID);
            }

            knowledge[agentID].Add(
                information
            );
        }


        public List<string> GetKnowledge(
            string agentID)
        {
            if (knowledge.ContainsKey(agentID))
            {
                return knowledge[agentID];
            }

            return new List<string>();
        }


        public bool Knows(
            string agentID,
            string information)
        {
            if (knowledge.ContainsKey(agentID))
            {
                return knowledge[agentID]
                    .Contains(information);
            }

            return false;
        }


        public void Forget(
            string agentID,
            string information)
        {
            if (knowledge.ContainsKey(agentID))
            {
                knowledge[agentID]
                    .Remove(information);
            }
        }
    }
}