using UnityEngine;
using System.Collections.Generic;

public class OmniWorldDatabaseSystem : MonoBehaviour
{
    public Dictionary<string, string> data =
        new Dictionary<string, string>();

    void Start()
    {
        InitializeDatabase();
    }

    void InitializeDatabase()
    {
        data.Add("Project", "OmniWorld AI");
        data.Add("Version", "1.0");
        data.Add("Status", "Active");

        Debug.Log("Database System Activated");
    }

    public void SaveData(string key, string value)
    {
        if (data.ContainsKey(key))
        {
            data[key] = value;
        }
        else
        {
            data.Add(key, value);
        }

        Debug.Log(
            "Data Saved: " + key
        );
    }

    public string LoadData(string key)
    {
        if (data.ContainsKey(key))
        {
            return data[key];
        }

        return "Data Not Found";
    }

    public bool HasData(string key)
    {
        return data.ContainsKey(key);
    }

    public int GetDatabaseSize()
    {
        return data.Count;
    }
}