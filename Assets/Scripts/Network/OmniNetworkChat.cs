using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OmniChatMessage
{
    public string senderName;
    public string message;
    public string sentAt;
}

public class OmniNetworkChat : MonoBehaviour
{
    [SerializeField] private int maxStoredMessages = 50;

    private readonly List<OmniChatMessage> messages = new();

    public event Action<OmniChatMessage> MessageReceived;

    public IReadOnlyList<OmniChatMessage> Messages => messages;

    public void SendMessage(string senderName, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        OmniChatMessage chatMessage = new OmniChatMessage
        {
            senderName = string.IsNullOrWhiteSpace(senderName) ? "Explorer" : senderName,
            message = text.Trim(),
            sentAt = DateTime.UtcNow.ToString("o")
        };

        messages.Add(chatMessage);

        if (messages.Count > maxStoredMessages)
        {
            messages.RemoveAt(0);
        }

        Debug.Log(chatMessage.senderName + ": " + chatMessage.message);
        MessageReceived?.Invoke(chatMessage);
    }

    public void ClearMessages()
    {
        messages.Clear();
    }
}