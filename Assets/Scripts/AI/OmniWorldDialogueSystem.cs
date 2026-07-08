using UnityEngine;
using System.Collections.Generic;

public class OmniWorldDialogueSystem : MonoBehaviour
{
    public List<string> dialogueLines = new List<string>();

    void Start()
    {
        LoadDefaultDialogue();
    }

    void LoadDefaultDialogue()
    {
        dialogueLines.Add("Welcome to OmniWorld AI");
        dialogueLines.Add("The universe is waiting to be explored");
        dialogueLines.Add("Your choices will shape this world");

        Debug.Log("Dialogue System Loaded");
    }

    public void AddDialogue(string line)
    {
        dialogueLines.Add(line);

        Debug.Log("Dialogue Added: " + line);
    }

    public string GetDialogue(int index)
    {
        if (index >= 0 && index < dialogueLines.Count)
        {
            return dialogueLines[index];
        }

        return "No dialogue available";
    }

    public int GetDialogueCount()
    {
        return dialogueLines.Count;
    }
}