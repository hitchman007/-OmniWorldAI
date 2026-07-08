using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIProceduralGenerator : MonoBehaviour
    {
        public static OmniWorldAIProceduralGenerator Instance;

        public int GeneratedObjects { get; private set; }


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


        public void GenerateObject(
            string objectType)
        {
            GeneratedObjects++;

            Debug.Log(
                "Procedural object generated: " +
                objectType
            );
        }


        public int GetGeneratedObjectCount()
        {
            return GeneratedObjects;
        }


        public void ResetGenerator()
        {
            GeneratedObjects = 0;
        }
    }
}