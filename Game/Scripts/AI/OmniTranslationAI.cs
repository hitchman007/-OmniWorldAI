using UnityEngine;

public class OmniTranslationAI : MonoBehaviour
{
    public string Translate(
        string text,
        string language)
    {
        Debug.Log(
        "Traduciendo a: " + language
        );

        return text;
    }
}