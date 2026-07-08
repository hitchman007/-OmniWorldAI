using UnityEngine;

public class OmniSaveManager : MonoBehaviour
{
    public void SavePlayer(string playerName)
    {
        PlayerPrefs.SetString(
            "PlayerName",
            playerName
        );

        PlayerPrefs.Save();

        Debug.Log(
        "Jugador guardado: " + playerName
        );
    }

    public string LoadPlayer()
    {
        string player =
        PlayerPrefs.GetString(
        "PlayerName",
        "Nuevo Jugador"
        );

        Debug.Log(
        "Jugador cargado: " + player
        );

        return player;
    }
}