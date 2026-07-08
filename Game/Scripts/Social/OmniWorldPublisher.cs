using UnityEngine;

public class OmniWorldPublisher : MonoBehaviour
{
    public string worldName;
    public bool published;

    public void PublishWorld(string name)
    {
        worldName = name;
        published = true;

        Debug.Log(
        "Mundo publicado: " + worldName
        );
    }

    public void RemoveWorld()
    {
        published = false;

        Debug.Log(
        "Mundo retirado"
        );
    }
}