using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIWorldBuilder : MonoBehaviour
    {
        public static OmniWorldAIWorldBuilder Instance;

        public bool BuilderActive { get; private set; }


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


        public void InitializeBuilder()
        {
            BuilderActive = true;

            Debug.Log(
                "OmniWorld AI World Builder Activated"
            );
        }


        public void ShutdownBuilder()
        {
            BuilderActive = false;

            Debug.Log(
                "OmniWorld AI World Builder Shutdown"
            );
        }


        public bool IsBuilderActive()
        {
            return BuilderActive;
        }
    }
}