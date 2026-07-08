using UnityEngine;

public class OmniServerCluster : MonoBehaviour
{
    public int activeWorlds;

    public void StartWorldServer(string worldID)
    {
        activeWorlds++;

        Debug.Log(
        "Servidor iniciado para mundo: "
        + worldID
        );
    }

    public void StopWorldServer()
    {
        activeWorlds--;

        Debug.Log(
        "Servidor de mundo detenido"
        );
    }
}