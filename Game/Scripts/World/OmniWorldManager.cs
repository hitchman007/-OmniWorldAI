using UnityEngine;

public class OmniWorldManager : MonoBehaviour
{
    public string currentWorld;

    public void LoadWorld(string worldName)
    {
        currentWorld = worldName;

        Debug.Log(
        "Mundo cargado: " + currentWorld
        );
    }

    public void CreateWorld(string worldName)
    {
        Debug.Log(
        "Creando mundo: " + worldName
        );
    }
}