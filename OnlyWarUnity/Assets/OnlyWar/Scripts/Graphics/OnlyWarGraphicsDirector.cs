using UnityEngine;
using UnityEngine.Rendering;

namespace OnlyWar {
  public sealed class OnlyWarGraphicsDirector : MonoBehaviour {
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;
    [Range(0,24)] public float hour=15f;
    public float dayLengthSeconds=1800f;
    public bool dynamicTime=true;

    void Start(){
      RenderSettings.ambientMode=AmbientMode.Trilight;
      RenderSettings.fog=true;
      RenderSettings.fogMode=FogMode.ExponentialSquared;
      RenderSettings.fogDensity=.004f;
    }

    void Update(){
      if(dynamicTime)hour=(hour+24f*Time.deltaTime/Mathf.Max(60f,dayLengthSeconds))%24f;
      float t=hour/24f;
      if(sun){
        sun.transform.rotation=Quaternion.Euler(t*360f-90f,155f,0f);
        sun.color=sunColor!=null?sunColor.Evaluate(t):Color.white;
        sun.intensity=sunIntensity!=null?sunIntensity.Evaluate(t):1.2f;
      }
      RenderSettings.fogColor=Color.Lerp(new Color(.08f,.10f,.13f),new Color(.55f,.62f,.65f),Mathf.Clamp01(Mathf.Sin(t*Mathf.PI)));
    }
  }
}
