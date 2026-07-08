using UnityEngine;

public class OmniRealityManager : MonoBehaviour
{
    public bool vrMode;
    public bool arMode;

    public void EnableVR()
    {
        vrMode = true;

        Debug.Log(
        "Modo VR activado"
        );
    }

    public void EnableAR()
    {
        arMode = true;

        Debug.Log(
        "Modo AR activado"
        );
    }
}