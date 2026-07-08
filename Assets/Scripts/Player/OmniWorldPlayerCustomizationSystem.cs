using UnityEngine;
using System.Collections.Generic;

public class OmniWorldPlayerCustomizationSystem : MonoBehaviour
{
    public string characterName = "Omni Creator";

    public List<string> unlockedStyles =
        new List<string>();

    void Start()
    {
        InitializeCustomization();
    }

    void InitializeCustomization()
    {
        unlockedStyles.Add("Default Suit");
        unlockedStyles.Add("Explorer Style");

        Debug.Log(
            "Customization System Activated"
        );
    }

    public void ChangeCharacterName(string newName)
    {
        characterName = newName;

        Debug.Log(
            "Character Name: " +
            characterName
        );
    }

    public void UnlockStyle(string styleName)
    {
        if (!unlockedStyles.Contains(styleName))
        {
            unlockedStyles.Add(styleName);

            Debug.Log(
                "Style Unlocked: " +
                styleName
            );
        }
    }

    public bool HasStyle(string styleName)
    {
        return unlockedStyles.Contains(styleName);
    }

    public int GetStyleCount()
    {
        return unlockedStyles.Count;
    }
}