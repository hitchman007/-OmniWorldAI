using UnityEngine;

public class OmniInputManager : MonoBehaviour
{
    public static OmniInputManager Instance;

    private Vector2 movementInput;

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

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        movementInput = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
    }

    public Vector2 GetMovement()
    {
        return movementInput;
    }
}