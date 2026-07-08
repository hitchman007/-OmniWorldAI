using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerChatManager : MonoBehaviour
    {
        public static OmniMultiplayerChatManager Instance;

        private List<string> chatHistory = new List<string>();


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


        public void SendChatMessage(string playerID, string message)
        {
            string chatMessage =
                playerID + ": " + message;

            chatHistory.Add(chatMessage);

            Debug.Log(chatMessage);
        }


        public List<string> GetChatHistory()
        {
            return chatHistory;
        }


        public void ClearChat()
        {
            chatHistory.Clear();
        }


        public int GetMessageCount()
        {
            return chatHistory.Count;
        }
    }
}