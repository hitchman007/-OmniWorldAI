using UnityEngine;
using System.Collections.Generic;

public class OmniWorldBackupSystem : MonoBehaviour
{
    public List<string> backups = new List<string>();

    public int maxBackups = 10;

    void Start()
    {
        Debug.Log("Backup System Activated");
    }

    public void CreateBackup(string backupName)
    {
        backups.Add(backupName);

        if (backups.Count > maxBackups)
        {
            backups.RemoveAt(0);
        }

        Debug.Log(
            "Backup Created: " + backupName
        );
    }

    public void RestoreBackup(string backupName)
    {
        if (backups.Contains(backupName))
        {
            Debug.Log(
                "Backup Restored: " + backupName
            );
        }
        else
        {
            Debug.Log("Backup Not Found");
        }
    }

    public int GetBackupCount()
    {
        return backups.Count;
    }
}