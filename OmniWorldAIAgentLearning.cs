using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentLearning : MonoBehaviour
    {
        public static OmniWorldAIAgentLearning Instance;

        private Dictionary<string, float> agentKnowledge =
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


        public void Learn(
            string agentID,
            float amount)
        {
            if (agentKnowledge.ContainsKey(agentID))
            {
                agentKnowledge[agentID] += amount;
            }
            else
            {
                agentKnowledge.Add(
                    agentID,
                    amount
                );
            }


            Debug.Log(
                "Agent learning updated: " +
                agentID
            );
        }


        public float GetKnowledge(
            string agentID)
        {
            if (agentKnowledge.ContainsKey(agentID))
            {
                return agentKnowledge[agentID];
            }

            return 0f;
        }


        public bool HasKnowledge(
            string agentID)
        {
            return agentKnowledge.ContainsKey(agentID);
        }


        public void ResetAgentLearning(
            string agentID)
        {
            if (agentKnowledge.ContainsKey(agentID))
            {
                agentKnowledge.Remove(agentID);
            }
        }


        public void ClearLearning()
        {
            agentKnowledge.Clear();
        }
    }
}