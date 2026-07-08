using UnityEngine;

public class OmniAccountManager : MonoBehaviour
{
    public string username;
    public string playerID;

    public void CreateAccount(string name)
    {
        username = name;

        playerID = 
        System.Guid.NewGuid().ToString();

        Debug.Log(
        "Cuenta creada: " + username
        );
    }

    public void LoadAccount()
    {
        Debug.Log(
        "Cargando cuenta: " + username
        );
    }
}