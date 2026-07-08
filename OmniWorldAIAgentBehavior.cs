using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentBehavior : MonoBehaviour
    {
        public static OmniWorldAIAgentBehavior Instance;

        private Dictionary<string, string> agentBehaviors =
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


        public void AssignBehavior(
            string agentID,
            string behavior)
        {
            if (agentBehaviors.ContainsKey(agentID))
            {
                agentBehaviors[agentID] = behavior;
            }
            else
            {
                agentBehaviors.Add(
                    agentID,
                    behavior
                );
            }
        }


        public string GetBehavior(
            string agentID)
        {
            if (agentBehaviors.ContainsKey(agentID))
            {
                return agentBehaviors[agentID];
            }

            return "Neutral";
        }


        public void UpdateBehavior(
            string agentID,
            string behavior)
        {
            AssignBehavior(
                agentID,
                behavior
            );
        }


        public void RemoveAgent(
            string agentID)
        {
            if (agentBehaviors.ContainsKey(agentID))
            {
                agentBehaviors.Remove(agentID);
            }
        }


        public int GetBehaviorCount()
        {
            return agentBehaviors.Count;
        }
    }
}