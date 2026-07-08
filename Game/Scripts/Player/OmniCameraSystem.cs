using UnityEngine;

public class OmniCameraSystem : MonoBehaviour
{
    public Transform target;

    public float distance = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position =
            target.position 
            - transform.forward * distance;
        }
    }
}