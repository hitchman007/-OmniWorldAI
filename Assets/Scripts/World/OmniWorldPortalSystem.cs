using UnityEngine;
using System.Collections.Generic;

public class OmniWorldPortalSystem : MonoBehaviour
{
    public List<string> connectedWorlds = new List<string>();

    void Start()
    {
        LoadDefaultPortals();
    }

    void LoadDefaultPortals()
    {
        connectedWorlds.Add("Genesis World");
        connectedWorlds.Add("Future City");
        connectedWorlds.Add("Alien Realm");

        Debug.Log("Portal System Activated");
    }

    public void CreatePortal(string worldName)
    {
        if (!connectedWorlds.Contains(worldName))
        {
            connectedWorlds.Add(worldName);

            Debug.Log("Portal Created To: " + worldName);
        }
    }

    public void TravelToWorld(string worldName)
    {
        if (connectedWorlds.Contains(worldName))
        {
            Debug.Log("Traveling To World: " + worldName);
        }
        else
        {
            Debug.Log("World Not Connected");
        }
    }

    public int GetPortalCount()
    {
        return connectedWorlds.Count;
    }
}