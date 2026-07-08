using UnityEngine;
using System.Collections.Generic;

public class OmniWorldCommunicationSystem : MonoBehaviour
{
    public List<string> messages =
        new List<string>();

    public int totalMessages = 0;

    void Start()
    {
        InitializeCommunication();
    }

    void InitializeCommunication()
    {
        Debug.Log(
            "Communication System Activated"
        );
    }

    public void SendMessage(string sender, string message)
    {
        string fullMessage =
            sender + ": " + message;

        messages.Add(fullMessage);

        totalMessages++;

        Debug.Log(
            fullMessage
        );
    }

    public string GetLastMessage()
    {
        if (messages.Count > 0)
        {
            return messages[messages.Count - 1];
        }

        return "No Messages";
    }

    public int GetMessageCount()
    {
        return totalMessages;
    }

    public void ClearMessages()
    {
        messages.Clear();

        Debug.Log(
            "Messages Cleared"
        );
    }
}