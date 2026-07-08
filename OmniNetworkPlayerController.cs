using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniNetworkPlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private OmniPlayerNetworkIdentity identity;

        private void Start()
        {
            identity = GetComponent<OmniPlayerNetworkIdentity>();

            if (identity != null)
            {
                identity.ConnectPlayer();
            }
        }


        private void Update()
        {
            if (identity == null || !identity.IsConnected)
                return;

            HandleMovement();
        }


        private void HandleMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(
                horizontal,
                0,
                vertical
            );

            transform.position += movement * moveSpeed * Time.deltaTime;
        }


        public void TeleportPlayer(Vector3 position)
        {
            transform.position = position;
        }
    }
}