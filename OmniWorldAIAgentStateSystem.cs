using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentStateSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentStateSystem Instance;

        private Dictionary<string, string> agentStates =
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


        public void SetState(
            string agentID,
            string state)
        {
            if (agentStates.ContainsKey(agentID))
            {
                agentStates[agentID] = state;
            }
            else
            {
                agentStates.Add(
                    agentID,
                    state
                );
            }
        }


        public string GetState(
            string agentID)
        {
            if (agentStates.ContainsKey(agentID))
            {
                return agentStates[agentID];
            }

            return "Unknown";
        }


        public bool HasState(
            string agentID)
        {
            return agentStates.ContainsKey(agentID);
        }


        public void RemoveState(
            string agentID)
        {
            if (agentStates.ContainsKey(agentID))
            {
                agentStates.Remove(agentID);
            }
        }


        public void ClearStates()
        {
            agentStates.Clear();
        }
    }
}