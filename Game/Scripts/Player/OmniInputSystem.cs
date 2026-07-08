using UnityEngine;

public class OmniInputSystem : MonoBehaviour
{
    public Vector3 movement;

    void Update()
    {
        float x =
        Input.GetAxis("Horizontal");

        float z =
        Input.GetAxis("Vertical");

        movement =
        new Vector3(x, 0, z);

        if (movement != Vector3.zero)
        {
            Debug.Log(
            "Movimiento: " + movement
            );
        }
    }
}