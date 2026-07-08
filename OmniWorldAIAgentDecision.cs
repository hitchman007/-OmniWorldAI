using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentDecision : MonoBehaviour
    {
        public static OmniWorldAIAgentDecision Instance;

        private Dictionary<string, string> agentDecisions =
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


        public void SetDecision(
            string agentID,
            string decision)
        {
            if (agentDecisions.ContainsKey(agentID))
            {
                agentDecisions[agentID] = decision;
            }
            else
            {
                agentDecisions.Add(
                    agentID,
                    decision
                );
            }


            Debug.Log(
                "Agent decision: " +
                agentID +
                " -> " +
                decision
            );
        }


        public string GetDecision(
            string agentID)
        {
            if (agentDecisions.ContainsKey(agentID))
            {
                return agentDecisions[agentID];
            }

            return "Idle";
        }


        public void RemoveDecision(
            string agentID)
        {
            if (agentDecisions.ContainsKey(agentID))
            {
                agentDecisions.Remove(agentID);
            }
        }


        public void ClearDecisions()
        {
            agentDecisions.Clear();
        }
    }
}