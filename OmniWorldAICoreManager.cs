using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAICoreManager : MonoBehaviour
    {
        public static OmniWorldAICoreManager Instance;

        public bool CoreActive { get; private set; }


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


        public void InitializeCore()
        {
            CoreActive = true;

            Debug.Log(
                "OmniWorld AI Core Activated"
            );
        }


        public void ShutdownCore()
        {
            CoreActive = false;

            Debug.Log(
                "OmniWorld AI Core Shutdown"
            );
        }


        public bool IsCoreActive()
        {
            return CoreActive;
        }
    }
}