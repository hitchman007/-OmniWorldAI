using UnityEngine;
using System.IO;

public class OmniWorldSaveSystem : MonoBehaviour
{
    public string worldData = "OmniWorld AI Data";

    private string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/omniworld_save.json";
    }

    public void SaveWorld()
    {
        WorldSaveData data = new WorldSaveData();
        data.content = worldData;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("World Saved: " + savePath);
    }

    public void LoadWorld()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            WorldSaveData data =
                JsonUtility.FromJson<WorldSaveData>(json);

            worldData = data.content;

            Debug.Log("World Loaded: " + worldData);
        }
        else
        {
            Debug.Log("No Save Found");
        }
    }
}

[System.Serializable]
public class WorldSaveData
{
    public string content;
}