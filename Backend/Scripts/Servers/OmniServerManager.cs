using UnityEngine;

public class OmniServerManager : MonoBehaviour
{
    public bool serverOnline;

    public void StartServer()
    {
        serverOnline = true;

        Debug.Log(
        "Servidor OmniWorld AI activo"
        );
    }

    public void StopServer()
    {
        serverOnline = false;

        Debug.Log(
        "Servidor detenido"
        );
    }
}