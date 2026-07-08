using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAILearningSystem : MonoBehaviour
    {
        public static OmniWorldAILearningSystem Instance;

        private Dictionary<string, float> knowledge =
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
            string concept,
            float value)
        {
            if (knowledge.ContainsKey(concept))
            {
                knowledge[concept] += value;
            }
            else
            {
                knowledge.Add(
                    concept,
                    value
                );
            }


            Debug.Log(
                "AI Learned: " + concept
            );
        }


        public float GetKnowledge(
            string concept)
        {
            if (knowledge.ContainsKey(concept))
            {
                return knowledge[concept];
            }

            return 0f;
        }


        public bool HasLearned(
            string concept)
        {
            return knowledge.ContainsKey(concept);
        }


        public void Forget(
            string concept)
        {
            if (knowledge.ContainsKey(concept))
            {
                knowledge.Remove(concept);
            }
        }


        public void ResetLearning()
        {
            knowledge.Clear();
        }
    }
}