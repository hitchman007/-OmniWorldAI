using UnityEngine;

public class OmniQAManager : MonoBehaviour
{
    public void RunTest(string testName)
    {
        Debug.Log(
        "Ejecutando prueba: " + testName
        );
    }

    public void ReportIssue(string issue)
    {
        Debug.Log(
        "Problema detectado: " + issue
        );
    }
}