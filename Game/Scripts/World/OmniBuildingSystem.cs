using UnityEngine;

public class OmniBuildingSystem : MonoBehaviour
{
    public int objectsBuilt;

    public void BuildObject(string objectName)
    {
        objectsBuilt++;

        Debug.Log(
        "Objeto construido: " + objectName
        );
    }

    public void RemoveObject(string objectName)
    {
        objectsBuilt--;

        Debug.Log(
        "Objeto eliminado: " + objectName
        );
    }
}