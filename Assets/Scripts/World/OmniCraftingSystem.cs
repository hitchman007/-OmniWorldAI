using UnityEngine;

public class OmniCraftingSystem : MonoBehaviour
{
    public static OmniCraftingSystem Instance;

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

    public void CraftItem(string itemName)
    {
        Debug.Log(
            "Item crafted: " + itemName
        );
    }

    public bool CanCraft(string itemName)
    {
        Debug.Log(
            "Checking recipe: " + itemName
        );

        return true;
    }
}