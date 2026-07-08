using UnityEngine;
using System.Collections.Generic;

public class OmniWorldMultiplayerChatSystem : MonoBehaviour
{
    public List<string> chatMessages = new List<string>();

    public int maxMessages = 100;

    void Start()
    {
        InitializeChat();
    }

    void InitializeChat()
    {
        chatMessages.Add("Welcome to OmniWorld Multiplayer");

        Debug.Log("Multiplayer Chat System Activated");
    }

    public void SendChatMessage(string playerName, string message)
    {
        string fullMessage = playerName + ": " + message;

        chatMessages.Add(fullMessage);

        if (chatMessages.Count > maxMessages)
        {
            chatMessages.RemoveAt(0);
        }

        Debug.Log(fullMessage);
    }

    public List<string> GetMessages()
    {
        return chatMessages;
    }

    public int GetMessageCount()
    {
        return chatMessages.Count;
    }
}