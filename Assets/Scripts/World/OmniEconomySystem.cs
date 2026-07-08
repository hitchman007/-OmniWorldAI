using UnityEngine;

public class OmniEconomySystem : MonoBehaviour
{
    public static OmniEconomySystem Instance;

    private int credits = 0;

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

    public void AddCredits(int amount)
    {
        credits += amount;

        Debug.Log(
            "Credits added: " + amount
        );
    }

    public bool SpendCredits(int amount)
    {
        if (credits >= amount)
        {
            credits -= amount;

            Debug.Log(
                "Credits spent: " + amount
            );

            return true;
        }

        return false;
    }

    public int GetCredits()
    {
        return credits;
    }
}