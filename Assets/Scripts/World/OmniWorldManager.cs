using UnityEngine;

public class OmniWorldManager : MonoBehaviour
{
    public static OmniWorldManager Instance;

    private string currentWorld;

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

    public void CreateWorld(string worldName)
    {
        currentWorld = worldName;

        Debug.Log("World created: " + worldName);
    }

    public string GetCurrentWorld()
    {
        return currentWorld;
    }

    public void LoadWorld()
    {
        Debug.Log("Loading world: " + currentWorld);
    }
}