using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerConnectionMonitor : MonoBehaviour
    {
        public static OmniMultiplayerConnectionMonitor Instance;

        public bool IsConnected { get; private set; }

        private float connectionTime;


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


        private void Update()
        {
            if (IsConnected)
            {
                connectionTime += Time.deltaTime;
            }
        }


        public void Connect()
        {
            IsConnected = true;
            connectionTime = 0;

            Debug.Log("OmniWorld AI connection established.");
        }


        public void Disconnect()
        {
            IsConnected = false;

            Debug.Log("OmniWorld AI connection closed.");
        }


        public float GetConnectionDuration()
        {
            return connectionTime;
        }


        public bool CheckConnection()
        {
            return IsConnected;
        }
    }
}