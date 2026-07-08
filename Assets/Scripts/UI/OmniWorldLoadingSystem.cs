using UnityEngine;

public class OmniWorldLoadingSystem : MonoBehaviour
{
    public float loadingProgress = 0f;
    public bool isLoading = false;

    void Start()
    {
        Debug.Log("Loading System Activated");
    }

    public void StartLoading()
    {
        isLoading = true;
        loadingProgress = 0f;

        Debug.Log("Loading Started");
    }

    public void UpdateLoading(float amount)
    {
        if (isLoading)
        {
            loadingProgress += amount;

            if (loadingProgress >= 100f)
            {
                loadingProgress = 100f;
                FinishLoading();
            }
        }
    }

    void FinishLoading()
    {
        isLoading = false;

        Debug.Log("Loading Complete");
    }

    public float GetProgress()
    {
        return loadingProgress;
    }
}