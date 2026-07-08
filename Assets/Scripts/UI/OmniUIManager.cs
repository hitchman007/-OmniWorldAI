using UnityEngine;

public class OmniUIManager : MonoBehaviour
{
    public static OmniUIManager Instance;

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

    public void OpenMenu(string menuName)
    {
        Debug.Log(
            "Opening UI menu: " + menuName
        );
    }

    public void CloseMenu(string menuName)
    {
        Debug.Log(
            "Closing UI menu: " + menuName
        );
    }
}