using System;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerEventManager : MonoBehaviour
    {
        public static OmniMultiplayerEventManager Instance;

        public event Action<string> OnPlayerJoined;
        public event Action<string> OnPlayerLeft;
        public event Action<string> OnMessageReceived;


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


        public void PlayerJoined(string playerID)
        {
            OnPlayerJoined?.Invoke(playerID);

            Debug.Log("Player joined event: " + playerID);
        }


        public void PlayerLeft(string playerID)
        {
            OnPlayerLeft?.Invoke(playerID);

            Debug.Log("Player left event: " + playerID);
        }


        public void MessageReceived(string message)
        {
            OnMessageReceived?.Invoke(message);

            Debug.Log("Message event: " + message);
        }
    }
}