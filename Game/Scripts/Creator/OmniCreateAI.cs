using UnityEngine;

public class OmniCreateAI : MonoBehaviour
{
    public string worldIdea;

    public void GenerateWorld(string idea)
    {
        worldIdea = idea;

        Debug.Log(
        "Generando mundo: " + worldIdea
        );
    }

    public void SaveCreation()
    {
        Debug.Log(
        "Creación guardada"
        );
    }
}