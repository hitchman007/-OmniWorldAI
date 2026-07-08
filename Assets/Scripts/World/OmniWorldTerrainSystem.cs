using UnityEngine;
using System.Collections.Generic;

public class OmniWorldTerrainSystem : MonoBehaviour
{
    public List<string> terrainTypes = new List<string>();

    public string currentTerrain = "Default";

    void Start()
    {
        InitializeTerrain();
    }

    void InitializeTerrain()
    {
        terrainTypes.Add("Mountains");
        terrainTypes.Add("Oceans");
        terrainTypes.Add("Forests");
        terrainTypes.Add("Deserts");

        Debug.Log("Terrain System Activated");
    }

    public void ChangeTerrain(string terrainName)
    {
        if (terrainTypes.Contains(terrainName))
        {
            currentTerrain = terrainName;

            Debug.Log(
                "Terrain Changed: " +
                currentTerrain
            );
        }
    }

    public void AddTerrainType(string terrainName)
    {
        if (!terrainTypes.Contains(terrainName))
        {
            terrainTypes.Add(terrainName);

            Debug.Log(
                "New Terrain Added: " +
                terrainName
            );
        }
    }

    public int GetTerrainCount()
    {
        return terrainTypes.Count;
    }
}