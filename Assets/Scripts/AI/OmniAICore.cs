using UnityEngine;

public class OmniAICore : MonoBehaviour
{
    public static OmniAICore Instance;

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

    public string ProcessRequest(string request)
    {
        Debug.Log("AI Request: " + request);

        return "AI response generated";
    }

    public void GenerateWorldIdea()
    {
        Debug.Log("Generating AI world concept...");
    }
}