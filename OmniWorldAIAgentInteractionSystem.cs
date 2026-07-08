using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentInteractionSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentInteractionSystem Instance;

        private Dictionary<string, List<string>> interactions =
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
            if (!interactions.ContainsKey(agentID))
            {
                interactions.Add(
                    agentID,
                    new List<string>()
                );
            }
        }


        public void AddInteraction(
            string agentID,
            string interaction)
        {
            if (!interactions.ContainsKey(agentID))
            {
                RegisterAgent(agentID);
            }

            interactions[agentID].Add(interaction);


            Debug.Log(
                "Agent interaction: " +
                interaction
            );
        }


        public List<string> GetInteractions(
            string agentID)
        {
            if (interactions.ContainsKey(agentID))
            {
                return interactions[agentID];
            }

            return new List<string>();
        }


        public void ClearInteractions(
            string agentID)
        {
            if (interactions.ContainsKey(agentID))
            {
                interactions[agentID].Clear();
            }
        }


        public void RemoveAgent(
            string agentID)
        {
            if (interactions.ContainsKey(agentID))
            {
                interactions.Remove(agentID);
            }
        }
    }
}