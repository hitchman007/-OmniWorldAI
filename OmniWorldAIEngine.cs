using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIEngine : MonoBehaviour
    {
        public static OmniWorldAIEngine Instance;

        public bool AIWorldActive { get; private set; }


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


        public void InitializeWorldAI()
        {
            AIWorldActive = true;

            Debug.Log(
                "OmniWorld AI Engine Initialized"
            );
        }


        public void ShutdownWorldAI()
        {
            AIWorldActive = false;

            Debug.Log(
                "OmniWorld AI Engine Shutdown"
            );
        }


        public bool IsAIActive()
        {
            return AIWorldActive;
        }
    }
}