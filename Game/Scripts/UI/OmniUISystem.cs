using UnityEngine;

public class OmniUISystem : MonoBehaviour
{
    public void OpenMenu(string menuName)
    {
        Debug.Log(
        "Abriendo menú: " + menuName
        );
    }

    public void CloseMenu(string menuName)
    {
        Debug.Log(
        "Cerrando menú: " + menuName
        );
    }
}