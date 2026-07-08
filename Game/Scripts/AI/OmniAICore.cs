using UnityEngine;

public class OmniAICore : MonoBehaviour
{
    public string aiName = "OmniAI";

    public string ProcessRequest(string request)
    {
        Debug.Log(
        "Solicitud IA: " + request
        );

        return "Procesando: " + request;
    }
}