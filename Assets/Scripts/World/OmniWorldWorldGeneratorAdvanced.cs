using UnityEngine;
using System.Collections.Generic;

public class OmniWorldWorldGeneratorAdvanced : MonoBehaviour
{
    public string worldName = "Omni Generated Universe";
    public int worldSize = 1000;

    public List<string> generatedZones = new List<string>();

    void Start()
    {
        GenerateBaseWorld();
    }

    void GenerateBaseWorld()
    {
        generatedZones.Add("Forest Zone");
        generatedZones.Add("City Zone");
        generatedZones.Add("Space Zone");

        Debug.Log("Advanced World Generator Activated");
        Debug.Log("World: " + worldName);
    }

    public void CreateNewZone(string zoneName)
    {
        if (!generatedZones.Contains(zoneName))
        {
            generatedZones.Add(zoneName);

            Debug.Log("New Zone Created: " + zoneName);
        }
    }

    public void RemoveZone(string zoneName)
    {
        if (generatedZones.Contains(zoneName))
        {
            generatedZones.Remove(zoneName);

            Debug.Log("Zone Removed: " + zoneName);
        }
    }

    public int GetZoneCount()
    {
        return generatedZones.Count;
    }
}