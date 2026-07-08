using UnityEngine;
using System.Collections.Generic;

public class OmniWorldMenuSystem : MonoBehaviour
{
    public List<string> menuOptions = new List<string>();

    public bool menuActive = false;

    void Start()
    {
        LoadMenuOptions();
    }

    void LoadMenuOptions()
    {
        menuOptions.Add("Create World");
        menuOptions.Add("Explore Universe");
        menuOptions.Add("Multiplayer");
        menuOptions.Add("Settings");

        Debug.Log("Menu System Activated");
    }

    public void OpenMenu()
    {
        menuActive = true;

        Debug.Log("Menu Opened");
    }

    public void CloseMenu()
    {
        menuActive = false;

        Debug.Log("Menu Closed");
    }

    public void SelectOption(string option)
    {
        if (menuOptions.Contains(option))
        {
            Debug.Log(
                "Selected: " + option
            );
        }
    }

    public int GetOptionCount()
    {
        return menuOptions.Count;
    }
}