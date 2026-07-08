using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentCommunication : MonoBehaviour
    {
        public static OmniWorldAIAgentCommunication Instance;

        private Dictionary<string, List<string>> messages =
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
            if (!messages.ContainsKey(agentID))
            {
                messages.Add(
                    agentID,
                    new List<string>()
                );
            }
        }


        public void SendMessage(
            string agentID,
            string message)
        {
            if (!messages.ContainsKey(agentID))
            {
                RegisterAgent(agentID);
            }

            messages[agentID].Add(message);

            Debug.Log(
                "Agent message sent: " + message
            );
        }


        public List<string> GetMessages(
            string agentID)
        {
            if (messages.ContainsKey(agentID))
            {
                return messages[agentID];
            }

            return new List<string>();
        }


        public void ClearMessages(
            string agentID)
        {
            if (messages.ContainsKey(agentID))
            {
                messages[agentID].Clear();
            }
        }


        public void RemoveAgent(
            string agentID)
        {
            if (messages.ContainsKey(agentID))
            {
                messages.Remove(agentID);
            }
        }
    }
}