using UnityEngine;

public class OmniWorldPlayerStatsSystem : MonoBehaviour
{
    public int health = 100;
    public int energy = 100;
    public int creativity = 100;

    void Start()
    {
        InitializeStats();
    }

    void InitializeStats()
    {
        Debug.Log(
            "Player Stats System Activated"
        );
    }

    public void ModifyHealth(int amount)
    {
        health += amount;

        health = Mathf.Clamp(
            health,
            0,
            100
        );

        Debug.Log(
            "Health: " +
            health
        );
    }

    public void ModifyEnergy(int amount)
    {
        energy += amount;

        energy = Mathf.Clamp(
            energy,
            0,
            100
        );

        Debug.Log(
            "Energy: " +
            energy
        );
    }

    public void IncreaseCreativity(int amount)
    {
        creativity += amount;

        Debug.Log(
            "Creativity: " +
            creativity
        );
    }

    public int GetPowerLevel()
    {
        return health +
               energy +
               creativity;
    }
}