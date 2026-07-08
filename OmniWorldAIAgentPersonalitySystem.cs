using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentPersonalitySystem : MonoBehaviour
    {
        public static OmniWorldAIAgentPersonalitySystem Instance;

        private Dictionary<string, string> personalities =
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


        public void CreatePersonality(
            string agentID,
            string personality)
        {
            if (personalities.ContainsKey(agentID))
            {
                personalities[agentID] = personality;
            }
            else
            {
                personalities.Add(
                    agentID,
                    personality
                );
            }


            Debug.Log(
                "Agent personality created: " +
                agentID
            );
        }


        public string GetPersonality(
            string agentID)
        {
            if (personalities.ContainsKey(agentID))
            {
                return personalities[agentID];
            }

            return "Default";
        }


        public void UpdatePersonality(
            string agentID,
            string personality)
        {
            CreatePersonality(
                agentID,
                personality
            );
        }


        public void RemovePersonality(
            string agentID)
        {
            if (personalities.ContainsKey(agentID))
            {
                personalities.Remove(agentID);
            }
        }


        public int GetPersonalityCount()
        {
            return personalities.Count;
        }
    }
}