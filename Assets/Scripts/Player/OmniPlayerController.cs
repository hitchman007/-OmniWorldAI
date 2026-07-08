using UnityEngine;

public class OmniPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 movement;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);

        transform.Translate(
            movement * moveSpeed * Time.deltaTime
        );
    }
}