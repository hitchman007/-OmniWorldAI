using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarQuality : MonoBehaviour {
    public void Apply(QualityTier tier) {
      int index = Mathf.Clamp((int)tier, 0, Mathf.Max(0, QualitySettings.names.Length - 1));
      QualitySettings.SetQualityLevel(index, true);
      switch (tier) {
        case QualityTier.Low:
          QualitySettings.shadowDistance = 35f; Application.targetFrameRate = 60; break;
        case QualityTier.Medium:
          QualitySettings.shadowDistance = 65f; Application.targetFrameRate = 60; break;
        case QualityTier.High:
          QualitySettings.shadowDistance = 100f; Application.targetFrameRate = 60; break;
        case QualityTier.Ultra:
          QualitySettings.shadowDistance = 145f; Application.targetFrameRate = 120; break;
      }
    }
  }
}
