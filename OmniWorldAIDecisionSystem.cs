using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIDecisionSystem : MonoBehaviour
    {
        public static OmniWorldAIDecisionSystem Instance;

        private Dictionary<string, string> decisions =
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


        public void MakeDecision(
            string entityID,
            string decision)
        {
            if (decisions.ContainsKey(entityID))
            {
                decisions[entityID] = decision;
            }
            else
            {
                decisions.Add(
                    entityID,
                    decision
                );
            }


            Debug.Log(
                "AI Decision: " +
                entityID +
                " -> " +
                decision
            );
        }


        public string GetDecision(
            string entityID)
        {
            if (decisions.ContainsKey(entityID))
            {
                return decisions[entityID];
            }

            return "None";
        }


        public void ClearDecision(
            string entityID)
        {
            if (decisions.ContainsKey(entityID))
            {
                decisions.Remove(entityID);
            }
        }


        public void ClearAllDecisions()
        {
            decisions.Clear();
        }
    }
}