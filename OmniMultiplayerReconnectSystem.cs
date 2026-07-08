using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerReconnectSystem : MonoBehaviour
    {
        public static OmniMultiplayerReconnectSystem Instance;

        public bool AutoReconnectEnabled { get; private set; }

        private int reconnectAttempts;


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


        public void EnableAutoReconnect()
        {
            AutoReconnectEnabled = true;

            reconnectAttempts = 0;
        }


        public void DisableAutoReconnect()
        {
            AutoReconnectEnabled = false;
        }


        public bool TryReconnect()
        {
            if (!AutoReconnectEnabled)
            {
                return false;
            }


            reconnectAttempts++;

            Debug.Log(
                "Reconnect attempt: " +
                reconnectAttempts
            );


            return true;
        }


        public int GetReconnectAttempts()
        {
            return reconnectAttempts;
        }


        public void ResetReconnect()
        {
            reconnectAttempts = 0;
        }
    }
}