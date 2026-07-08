using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerCoreManager : MonoBehaviour
    {
        public static OmniMultiplayerCoreManager Instance;

        public bool MultiplayerActive { get; private set; }


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


        public void InitializeMultiplayer()
        {
            MultiplayerActive = true;

            Debug.Log(
                "OmniWorld AI Multiplayer Core Initialized"
            );
        }


        public void ShutdownMultiplayer()
        {
            MultiplayerActive = false;

            Debug.Log(
                "OmniWorld AI Multiplayer Core Shutdown"
            );
        }


        public bool IsMultiplayerRunning()
        {
            return MultiplayerActive;
        }
    }
}