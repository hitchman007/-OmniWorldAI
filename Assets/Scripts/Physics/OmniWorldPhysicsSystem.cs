using UnityEngine;

public class OmniWorldPhysicsSystem : MonoBehaviour
{
    public float gravity = -9.81f;
    public float worldMassMultiplier = 1f;

    public bool physicsEnabled = true;

    void Start()
    {
        InitializePhysics();
    }

    void InitializePhysics()
    {
        Debug.Log("Physics System Activated");
    }

    public void SetGravity(float value)
    {
        gravity = value;

        Debug.Log(
            "Gravity Changed: " + gravity
        );
    }

    public void SetMassMultiplier(float value)
    {
        worldMassMultiplier = value;

        Debug.Log(
            "Mass Multiplier: " +
            worldMassMultiplier
        );
    }

    public void TogglePhysics()
    {
        physicsEnabled = !physicsEnabled;

        Debug.Log(
            "Physics Enabled: " +
            physicsEnabled
        );
    }

    public bool IsPhysicsActive()
    {
        return physicsEnabled;
    }
}