using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentRelationshipSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentRelationshipSystem Instance;

        private Dictionary<string, float> relationships =
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


        private string CreateKey(
            string agentA,
            string agentB)
        {
            return agentA + "_" + agentB;
        }


        public void SetRelationship(
            string agentA,
            string agentB,
            float value)
        {
            string key =
                CreateKey(agentA, agentB);


            if (relationships.ContainsKey(key))
            {
                relationships[key] = value;
            }
            else
            {
                relationships.Add(
                    key,
                    value
                );
            }
        }


        public float GetRelationship(
            string agentA,
            string agentB)
        {
            string key =
                CreateKey(agentA, agentB);


            if (relationships.ContainsKey(key))
            {
                return relationships[key];
            }

            return 0f;
        }


        public void ChangeRelationship(
            string agentA,
            string agentB,
            float amount)
        {
            float current =
                GetRelationship(agentA, agentB);


            SetRelationship(
                agentA,
                agentB,
                current + amount
            );
        }


        public void ClearRelationships()
        {
            relationships.Clear();
        }
    }
}