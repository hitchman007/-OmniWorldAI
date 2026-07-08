using UnityEngine;
using System.Collections.Generic;

public class OmniWorldResourceSystem : MonoBehaviour
{
    public Dictionary<string, int> resources = new Dictionary<string, int>();

    void Start()
    {
        InitializeResources();
    }

    void InitializeResources()
    {
        resources.Add("Energy", 100);
        resources.Add("Crystal", 50);
        resources.Add("Metal", 75);

        Debug.Log("Resource System Initialized");
    }

    public void AddResource(string resourceName, int amount)
    {
        if (resources.ContainsKey(resourceName))
        {
            resources[resourceName] += amount;
        }
        else
        {
            resources.Add(resourceName, amount);
        }

        Debug.Log("Resource Added: " + resourceName);
    }

    public bool UseResource(string resourceName, int amount)
    {
        if (resources.ContainsKey(resourceName) &&
            resources[resourceName] >= amount)
        {
            resources[resourceName] -= amount;

            Debug.Log("Resource Used: " + resourceName);
            return true;
        }

        return false;
    }

    public int GetResourceAmount(string resourceName)
    {
        if (resources.ContainsKey(resourceName))
        {
            return resources[resourceName];
        }

        return 0;
    }
}