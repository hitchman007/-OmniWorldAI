using UnityEngine;

public class OmniAIPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string playerID = "Player_001";

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        transform.Translate(
            movement * moveSpeed * Time.deltaTime
        );
    }

    public void SetPlayerID(string id)
    {
        playerID = id;
        Debug.Log("Player ID: " + playerID);
    }
}