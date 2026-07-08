using UnityEngine;

public class OmniProgressionSystem : MonoBehaviour
{
    public int level = 1;
    public int experience;

    public void AddExperience(int amount)
    {
        experience += amount;

        Debug.Log(
        "Experiencia añadida: " + amount
        );

        CheckLevel();
    }

    void CheckLevel()
    {
        if (experience >= 100)
        {
            level++;

            experience = 0;

            Debug.Log(
            "Nuevo nivel: " + level
            );
        }
    }
}