using UnityEngine;

public class OmniConfig : MonoBehaviour
{
    public string gameName = "OmniWorld AI";

    public string version = "Alpha 1.0";

    public void ShowConfig()
    {
        Debug.Log(
        gameName + " - " + version
        );
    }
}