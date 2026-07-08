using UnityEngine;
using System.Collections.Generic;

public class OmniWorldDecisionAISystem : MonoBehaviour
{
    public string currentDecision = "Waiting";

    public List<string> decisionHistory =
        new List<string>();

    void Start()
    {
        InitializeAI();
    }

    void InitializeAI()
    {
        Debug.Log("Decision AI System Activated");
    }

    public void MakeDecision(string situation)
    {
        string decision;

        if (situation.ToLower().Contains("danger"))
        {
            decision = "Protect The World";
        }
        else if (situation.ToLower().Contains("resource"))
        {
            decision = "Collect Resources";
        }
        else if (situation.ToLower().Contains("explore"))
        {
            decision = "Explore New Area";
        }
        else
        {
            decision = "Continue Monitoring";
        }

        currentDecision = decision;
        decisionHistory.Add(decision);

        Debug.Log(
            "AI Decision: " +
            currentDecision
        );
    }

    public string GetCurrentDecision()
    {
        return currentDecision;
    }

    public int GetDecisionCount()
    {
        return decisionHistory.Count;
    }
}