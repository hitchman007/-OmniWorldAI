using UnityEngine;

public class OmniMarketplaceSystem : MonoBehaviour
{
    public static OmniMarketplaceSystem Instance;

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

    public void ListItem(string itemName)
    {
        Debug.Log(
            "Item listed: " + itemName
        );
    }

    public void PurchaseItem(string itemName)
    {
        Debug.Log(
            "Item purchased: " + itemName
        );
    }
}