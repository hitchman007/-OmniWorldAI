using UnityEngine;
using System.Collections.Generic;

public class OmniWorldAIChatSystem : MonoBehaviour
{
    public List<string> messages = new List<string>();

    public string aiName = "Omni Assistant";

    void Start()
    {
        InitializeChat();
    }

    void InitializeChat()
    {
        messages.Add("Welcome to OmniWorld AI");
        messages.Add("How can I help you create your world?");

        Debug.Log("AI Chat System Activated");
    }

    public void SendMessageToAI(string message)
    {
        messages.Add("Player: " + message);

        string response = GenerateResponse(message);

        messages.Add(aiName + ": " + response);

        Debug.Log(response);
    }

    string GenerateResponse(string input)
    {
        if (input.ToLower().Contains("build"))
        {
            return "I will help you build a new world.";
        }

        if (input.ToLower().Contains("explore"))
        {
            return "Preparing new dimensions to explore.";
        }

        return "Your idea has been recorded.";
    }

    public int GetMessageCount()
    {
        return messages.Count;
    }
}