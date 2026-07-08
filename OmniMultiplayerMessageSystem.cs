using System;
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerMessageSystem : MonoBehaviour
    {
        public static OmniMultiplayerMessageSystem Instance;

        private List<string> messages = new List<string>();


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


        public void SendMessageToWorld(string senderID, string message)
        {
            string formattedMessage =
                "[" + senderID + "] " + message;

            messages.Add(formattedMessage);

            Debug.Log(formattedMessage);
        }


        public List<string> GetMessages()
        {
            return messages;
        }


        public void ClearMessages()
        {
            messages.Clear();
        }


        public void RemoveMessage(string message)
        {
            if (messages.Contains(message))
            {
                messages.Remove(message);
            }
        }
    }
}