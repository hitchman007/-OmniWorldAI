using UnityEngine;

public class OmniEconomyManager : MonoBehaviour
{
    public int playerCredits;

    public void AddCredits(int amount)
    {
        playerCredits += amount;

        Debug.Log(
        "Créditos añadidos: " + amount
        );
    }

    public void SpendCredits(int amount)
    {
        playerCredits -= amount;

        Debug.Log(
        "Créditos usados: " + amount
        );
    }
}