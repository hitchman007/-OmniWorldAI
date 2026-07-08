using UnityEngine;

public class OmniSecurityManager : MonoBehaviour
{
    public bool securityActive;

    public void ActivateSecurity()
    {
        securityActive = true;

        Debug.Log(
        "Seguridad OmniWorld AI activa"
        );
    }

    public void CheckAccess(string userID)
    {
        Debug.Log(
        "Verificando acceso: " + userID
        );
    }
}