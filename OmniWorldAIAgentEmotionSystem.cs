using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentEmotionSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentEmotionSystem Instance;

        private Dictionary<string, float> emotions =
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


        public void SetEmotion(
            string agentID,
            float value)
        {
            if (emotions.ContainsKey(agentID))
            {
                emotions[agentID] = value;
            }
            else
            {
                emotions.Add(
                    agentID,
                    value
                );
            }
        }


        public void ChangeEmotion(
            string agentID,
            float amount)
        {
            float current =
                GetEmotion(agentID);

            SetEmotion(
                agentID,
                current + amount
            );
        }


        public float GetEmotion(
            string agentID)
        {
            if (emotions.ContainsKey(agentID))
            {
                return emotions[agentID];
            }

            return 0f;
        }


        public void ResetEmotion(
            string agentID)
        {
            if (emotions.ContainsKey(agentID))
            {
                emotions.Remove(agentID);
            }
        }


        public void ClearEmotions()
        {
            emotions.Clear();
        }
    }
}