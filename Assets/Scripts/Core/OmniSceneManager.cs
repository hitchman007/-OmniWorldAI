using UnityEngine;
using UnityEngine.SceneManagement;

public class OmniSceneManager : MonoBehaviour
{
    public static OmniSceneManager Instance;

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

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}