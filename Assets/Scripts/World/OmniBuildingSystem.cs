using UnityEngine;

public class OmniBuildingSystem : MonoBehaviour
{
    public static OmniBuildingSystem Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaceObject(string objectName, Vector3 position)
    {
        Debug.Log(
            "Object placed: " + objectName +
            " at " + position
        );
    }

    public void RemoveObject(string objectName)
    {
        Debug.Log("Object removed: " + objectName);
    }
}