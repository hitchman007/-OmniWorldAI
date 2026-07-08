using UnityEngine;

public class OmniDayNightSystem : MonoBehaviour
{
    public static OmniDayNightSystem Instance;

    private float timeOfDay;

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
        UpdateTime();
    }

    private void UpdateTime()
    {
        timeOfDay += Time.deltaTime;

        if (timeOfDay >= 24f)
        {
            timeOfDay = 0f;
        }
    }

    public float GetTime()
    {
        return timeOfDay;
    }
}