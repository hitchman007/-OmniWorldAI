using UnityEngine;

public class OmniWorldUserInterfaceSystem : MonoBehaviour
{
    public bool menuOpen = false;
    public string currentPanel = "Main Menu";

    void Start()
    {
        Debug.Log("UI System Activated");
    }

    public void OpenMenu()
    {
        menuOpen = true;

        Debug.Log("Menu Opened");
    }

    public void CloseMenu()
    {
        menuOpen = false;

        Debug.Log("Menu Closed");
    }

    public void ChangePanel(string panelName)
    {
        currentPanel = panelName;

        Debug.Log(
            "Current Panel: " + currentPanel
        );
    }

    public string GetCurrentPanel()
    {
        return currentPanel;
    }

    public bool IsMenuOpen()
    {
        return menuOpen;
    }
}