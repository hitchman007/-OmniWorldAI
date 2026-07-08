using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIEvolutionSystem : MonoBehaviour
    {
        public static OmniWorldAIEvolutionSystem Instance;

        public int EvolutionLevel { get; private set; }

        public float EvolutionProgress { get; private set; }


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


        public void AddProgress(
            float amount)
        {
            EvolutionProgress += amount;


            if (EvolutionProgress >= 100f)
            {
                EvolutionLevel++;

                EvolutionProgress = 0f;


                Debug.Log(
                    "World AI evolved to level: " +
                    EvolutionLevel
                );
            }
        }


        public int GetEvolutionLevel()
        {
            return EvolutionLevel;
        }


        public float GetEvolutionProgress()
        {
            return EvolutionProgress;
        }


        public void ResetEvolution()
        {
            EvolutionLevel = 0;

            EvolutionProgress = 0f;
        }
    }
}