using UnityEngine;

public class OmniNPCController : MonoBehaviour
{
    public string npcName = "NPC";

    private void Start()
    {
        InitializeNPC();
    }

    private void InitializeNPC()
    {
        Debug.Log(
            npcName + " initialized"
        );
    }

    public void Talk(string message)
    {
        Debug.Log(
            npcName + ": " + message
        );
    }

    public void AssignTask(string task)
    {
        Debug.Log(
            npcName + " task: " + task
        );
    }
}