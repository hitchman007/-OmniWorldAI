using UnityEngine;

public class OmniGameManager : MonoBehaviour
{
    public string gameVersion = "Alpha 1.0";

    void Start()
    {
        Debug.Log(
        "OmniWorld AI iniciado: "
        + gameVersion
        );
    }

    public void StartGame()
    {
        Debug.Log(
        "Entrando al universo OmniWorld"
        );
    }

    public void ExitGame()
    {
        Debug.Log(
        "Cerrando OmniWorld AI"
        );
    }
}