using UnityEngine;

public class OmniPlayerManager : MonoBehaviour
{
    public string playerName;

    public void SetPlayerName(string name)
    {
        playerName = name;

        Debug.Log(
        "Jugador: " + playerName
        );
    }
}