using UnityEngine;
using System.Collections.Generic;

public class OmniWorldMultiverseSystem : MonoBehaviour
{
    public List<string> universes = new List<string>();

    public string currentUniverse = "Genesis Universe";

    void Start()
    {
        InitializeMultiverse();
    }

    void InitializeMultiverse()
    {
        universes.Add("Genesis Universe");
        universes.Add("Cyber Universe");
        universes.Add("Alien Universe");
        universes.Add("Future Universe");

        Debug.Log("Multiverse System Activated");
    }

    public void CreateUniverse(string universeName)
    {
        if (!universes.Contains(universeName))
        {
            universes.Add(universeName);

            Debug.Log("Universe Created: " + universeName);
        }
    }

    public void TravelUniverse(string universeName)
    {
        if (universes.Contains(universeName))
        {
            currentUniverse = universeName;

            Debug.Log(
                "Traveling To: " + currentUniverse
            );
        }
        else
        {
            Debug.Log("Universe Not Found");
        }
    }

    public int GetUniverseCount()
    {
        return universes.Count;
    }
}