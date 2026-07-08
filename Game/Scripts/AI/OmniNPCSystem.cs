using UnityEngine;

public class OmniNPCSystem : MonoBehaviour
{
    public string npcName;

    public void SetNPCName(string name)
    {
        npcName = name;

        Debug.Log(
        "NPC creado: " + npcName
        );
    }

    public void Talk(string message)
    {
        Debug.Log(
        npcName + ": " + message
        );
    }
}