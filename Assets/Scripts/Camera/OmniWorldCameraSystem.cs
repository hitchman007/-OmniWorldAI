using UnityEngine;

public class OmniWorldCameraSystem : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public float zoomLevel = 10f;

    public bool firstPersonMode = true;

    void Start()
    {
        InitializeCamera();
    }

    void InitializeCamera()
    {
        Debug.Log("Camera System Activated");
    }

    public void SetZoom(float value)
    {
        zoomLevel = Mathf.Clamp(value, 1f, 100f);

        Debug.Log(
            "Zoom Level: " + zoomLevel
        );
    }

    public void SwitchCameraMode()
    {
        firstPersonMode = !firstPersonMode;

        Debug.Log(
            "First Person Mode: " + firstPersonMode
        );
    }

    public void MoveCamera(Vector3 direction)
    {
        transform.Translate(
            direction * cameraSpeed * Time.deltaTime
        );
    }

    public bool IsFirstPerson()
    {
        return firstPersonMode;
    }
}