using UnityEngine;

public class OmniTerrainSystem : MonoBehaviour
{
    public string terrainType;

    public void CreateTerrain(string type)
    {
        terrainType = type;

        Debug.Log(
        "Terreno creado: " + terrainType
        );
    }

    public void ModifyTerrain(string change)
    {
        Debug.Log(
        "Modificando terreno: " + change
        );
    }
}