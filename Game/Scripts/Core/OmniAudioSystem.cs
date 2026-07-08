using UnityEngine;

public class OmniAudioSystem : MonoBehaviour
{
    public void PlayMusic(string musicName)
    {
        Debug.Log(
        "Reproduciendo música: " + musicName
        );
    }

    public void PlaySound(string soundName)
    {
        Debug.Log(
        "Sonido: " + soundName
        );
    }
}