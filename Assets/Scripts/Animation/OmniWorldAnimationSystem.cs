using UnityEngine;

public class OmniWorldAnimationSystem : MonoBehaviour
{
    public string currentAnimation = "Idle";
    public float animationSpeed = 1f;

    void Start()
    {
        InitializeAnimation();
    }

    void InitializeAnimation()
    {
        Debug.Log("Animation System Activated");
    }

    public void PlayAnimation(string animationName)
    {
        currentAnimation = animationName;

        Debug.Log(
            "Playing Animation: " +
            currentAnimation
        );
    }

    public void SetAnimationSpeed(float speed)
    {
        animationSpeed = speed;

        Debug.Log(
            "Animation Speed: " +
            animationSpeed
        );
    }

    public string GetCurrentAnimation()
    {
        return currentAnimation;
    }
}