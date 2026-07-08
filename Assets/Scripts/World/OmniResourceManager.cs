using System.Collections.Generic;
using UnityEngine;

public class OmniResourceManager : MonoBehaviour
{
    public static OmniResourceManager Instance;

    private Dictionary<string, int> resources =
        new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

        Debug.Log(
            "Resource added: " + resourceName
        );
    }

    public int GetResource(string resourceName)
    {
        if (resources.ContainsKey(resourceName))
        {
            return resources[resourceName];
        }

        return 0;
    }
}