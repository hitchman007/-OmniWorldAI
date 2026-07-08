using UnityEngine;

public class OmniWorldStorage : MonoBehaviour
{
    public void SaveWorld(string worldID)
    {
        Debug.Log(
        "Guardando mundo: " + worldID
        );
    }

    public void LoadWorld(string worldID)
    {
        Debug.Log(
        "Cargando mundo: " + worldID
        );
    }
}