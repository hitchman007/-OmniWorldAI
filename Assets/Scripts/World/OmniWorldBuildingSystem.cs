using UnityEngine;
using System.Collections.Generic;

public class OmniWorldBuildingSystem : MonoBehaviour
{
    public List<string> buildings = new List<string>();

    void Start()
    {
        LoadStarterBuildings();
    }

    void LoadStarterBuildings()
    {
        buildings.Add("AI Headquarters");
        buildings.Add("Energy Station");
        buildings.Add("World Portal");

        Debug.Log("Building System Ready");
    }

    public void CreateBuilding(string buildingName)
    {
        if (!buildings.Contains(buildingName))
        {
            buildings.Add(buildingName);

            Debug.Log("Building Created: " + buildingName);
        }
    }

    public void RemoveBuilding(string buildingName)
    {
        if (buildings.Contains(buildingName))
        {
            buildings.Remove(buildingName);

            Debug.Log("Building Removed: " + buildingName);
        }
    }

    public int GetBuildingCount()
    {
        return buildings.Count;
    }
}