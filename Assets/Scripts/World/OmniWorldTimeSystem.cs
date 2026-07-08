using UnityEngine;

public class OmniWorldTimeSystem : MonoBehaviour
{
    public float worldTime = 12f;
    public float timeSpeed = 1f;

    public bool isDay;

    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        worldTime += Time.deltaTime * timeSpeed;

        if (worldTime >= 24f)
        {
            worldTime = 0f;
        }

        isDay = worldTime >= 6f && worldTime <= 18f;
    }

    public string GetCurrentTime()
    {
        if (isDay)
        {
            return "Day";
        }

        return "Night";
    }

    public void SetTime(float newTime)
    {
        worldTime = newTime;
    }
}