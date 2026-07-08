using UnityEngine;
using UnityEngine.SceneManagement;

public class OmniSceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        Debug.Log(
        "Cargando escena: " + sceneName
        );
    }

    public void ReloadScene()
    {
        Scene current =
        SceneManager.GetActiveScene();

        SceneManager.LoadScene(
        current.name
        );
    }
}