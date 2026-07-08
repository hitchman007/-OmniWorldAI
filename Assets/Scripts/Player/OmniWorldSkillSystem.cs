using UnityEngine;
using System.Collections.Generic;

public class OmniWorldSkillSystem : MonoBehaviour
{
    public List<string> skills =
        new List<string>();

    public int skillPoints = 0;

    void Start()
    {
        InitializeSkills();
    }

    void InitializeSkills()
    {
        skills.Add("World Creation");
        skills.Add("AI Communication");

        Debug.Log(
            "Skill System Activated"
        );
    }

    public void UnlockSkill(string skillName)
    {
        if (!skills.Contains(skillName))
        {
            skills.Add(skillName);

            skillPoints += 10;

            Debug.Log(
                "Skill Unlocked: " +
                skillName
            );
        }
    }

    public bool HasSkill(string skillName)
    {
        return skills.Contains(skillName);
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }

    public int GetSkillCount()
    {
        return skills.Count;
    }
}