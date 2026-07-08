using UnityEngine;

public class OmniAIWorldGenerator : MonoBehaviour
{
    public static OmniAIWorldGenerator Instance;

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

    public string GenerateWorld(string theme)
    {
        string worldIdea =
            "AI World generated with theme: "
            + theme;

        Debug.Log(worldIdea);

        return worldIdea;
    }

    public string GenerateObject(string type)
    {
        return "AI Object: " + type;
    }
}