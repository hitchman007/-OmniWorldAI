using UnityEngine;
using System.Collections.Generic;

public class OmniWorldSkillSystem : MonoBehaviour
{
    public List<string> unlockedSkills = new List<string>();

    void Start()
    {
        InitializeSkills();
    }

    void InitializeSkills()
    {
        unlockedSkills.Add("AI Creation");
        unlockedSkills.Add("World Editing");
        unlockedSkills.Add("Portal Control");

        Debug.Log("Skill System Activated");
    }

    public void UnlockSkill(string skillName)
    {
        if (!unlockedSkills.Contains(skillName))
        {
            unlockedSkills.Add(skillName);

            Debug.Log("Skill Unlocked: " + skillName);
        }
    }

    public bool HasSkill(string skillName)
    {
        return unlockedSkills.Contains(skillName);
    }

    public int GetSkillCount()
    {
        return unlockedSkills.Count;
    }
}