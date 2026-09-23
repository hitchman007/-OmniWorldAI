using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarAdaptivePerformance : MonoBehaviour {
    public OnlyWarQuality quality;
    public QualityTier tier=QualityTier.High;
    public float targetFps=60f;
    public float minScale=.72f;
    public float maxScale=1f;
    public float scale=1f;
    float avg=.0166f,timer;

    void Awake(){
      if(!quality)quality=FindFirstObjectByType<OnlyWarQuality>();
      AutoTier();
    }

    void AutoTier(){
      int ram=SystemInfo.systemMemorySize, vram=SystemInfo.graphicsMemorySize;
      tier=(ram>=6000&&vram>=2500)?QualityTier.Ultra:(ram>=4000?QualityTier.High:ram>=3000?QualityTier.Medium:QualityTier.Low);
      quality?.Apply(tier);
      targetFps=tier==QualityTier.Ultra?90f:60f;
      Application.targetFrameRate=Mathf.RoundToInt(targetFps);
    }

    void Update(){
      avg=Mathf.Lerp(avg,Time.unscaledDeltaTime,.05f);timer+=Time.unscaledDeltaTime;if(timer<1f)return;timer=0f;
      float fps=1f/Mathf.Max(.001f,avg);
      if(fps<targetFps*.84f)scale=Mathf.Max(minScale,scale-.06f);
      else if(fps>targetFps*.96f)scale=Mathf.Min(maxScale,scale+.035f);
      ScalableBufferManager.ResizeBuffers(scale,scale);
    }
  }
}
