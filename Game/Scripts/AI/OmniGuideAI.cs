using UnityEngine;

public class OmniGuideAI : MonoBehaviour
{
    public string guideName = "OmniGuide";

    public void WelcomePlayer()
    {
        Debug.Log(
        "Bienvenido a OmniWorld AI"
        );
    }

    public void GiveAdvice(string message)
    {
        Debug.Log(
        "OmniGuide: " + message
        );
    }
}