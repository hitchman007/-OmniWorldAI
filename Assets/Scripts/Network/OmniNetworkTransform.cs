using UnityEngine;

public class OmniNetworkTransform : MonoBehaviour
{
    [SerializeField] private bool isLocalPlayer;
    [SerializeField] private float positionLerpSpeed = 12f;
    [SerializeField] private float rotationLerpSpeed = 12f;

    private Vector3 networkPosition;
    private Quaternion networkRotation;

    private void Awake()
    {
        networkPosition = transform.position;
        networkRotation = transform.rotation;
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            SendTransformUpdate();
        }
        else
        {
            ReceiveTransformUpdate();
        }
    }

    private void SendTransformUpdate()
    {
        networkPosition = transform.position;
        networkRotation = transform.rotation;
    }

    private void ReceiveTransformUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            networkPosition,
            Time.deltaTime * positionLerpSpeed
        );

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            networkRotation,
            Time.deltaTime * rotationLerpSpeed
        );
    }

    public void SetNetworkTransform(Vector3 newPosition, Quaternion newRotation)
    {
        networkPosition = newPosition;
        networkRotation = newRotation;
    }

    public Vector3 GetNetworkPosition()
    {
        return networkPosition;
    }

    public Quaternion GetNetworkRotation()
    {
        return networkRotation;
    }
}