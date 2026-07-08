using UnityEngine;

public class OmniBehaviorAI : MonoBehaviour
{
    public string behavior;

    public void SetBehavior(string newBehavior)
    {
        behavior = newBehavior;

        Debug.Log(
        "Comportamiento: " + behavior
        );
    }

    public void ExecuteBehavior()
    {
        Debug.Log(
        "Ejecutando: " + behavior
        );
    }
}