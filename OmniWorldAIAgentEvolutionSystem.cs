using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentEvolutionSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentEvolutionSystem Instance;

        private Dictionary<string, int> evolutionLevels =
            new Dictionary<string, int>();


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


        public void AddEvolution(
            string agentID)
        {
            if (evolutionLevels.ContainsKey(agentID))
            {
                evolutionLevels[agentID]++;
            }
            else
            {
                evolutionLevels.Add(
                    agentID,
                    1
                );
            }


            Debug.Log(
                "Agent evolved: " +
                agentID
            );
        }


        public int GetEvolutionLevel(
            string agentID)
        {
            if (evolutionLevels.ContainsKey(agentID))
            {
                return evolutionLevels[agentID];
            }

            return 0;
        }


        public void SetEvolutionLevel(
            string agentID,
            int level)
        {
            if (evolutionLevels.ContainsKey(agentID))
            {
                evolutionLevels[agentID] = level;
            }
            else
            {
                evolutionLevels.Add(
                    agentID,
                    level
                );
            }
        }


        public void ResetEvolution(
            string agentID)
        {
            if (evolutionLevels.ContainsKey(agentID))
            {
                evolutionLevels.Remove(agentID);
            }
        }


        public void ClearEvolution()
        {
            evolutionLevels.Clear();
        }
    }
}