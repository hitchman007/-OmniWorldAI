using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIGenerator : MonoBehaviour
    {
        public static OmniWorldAIGenerator Instance;

        public int GeneratedWorlds { get; private set; }


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


        public void GenerateWorld(string worldName)
        {
            GeneratedWorlds++;

            Debug.Log(
                "AI World Generated: " + worldName
            );
        }


        public int GetGeneratedWorldCount()
        {
            return GeneratedWorlds;
        }


        public void ResetGenerator()
        {
            GeneratedWorlds = 0;
        }
    }
}