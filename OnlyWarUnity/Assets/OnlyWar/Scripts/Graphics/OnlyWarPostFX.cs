using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace OnlyWar {
  public sealed class OnlyWarPostFX : MonoBehaviour {
    public Volume volume;
    public bool enableBloom=true;
    public bool enableVignette=true;
    public bool enableColorGrade=true;

    void Awake(){
      if(!volume)volume=GetComponent<Volume>();
      if(!volume)volume=gameObject.AddComponent<Volume>();
      volume.isGlobal=true;
      var p=ScriptableObject.CreateInstance<VolumeProfile>();
      volume.profile=p;

      if(enableBloom){
        var bloom=p.Add<Bloom>();
        bloom.active=true;
        bloom.intensity.Override(.35f);
        bloom.threshold.Override(1.15f);
        bloom.scatter.Override(.55f);
      }
      if(enableVignette){
        var v=p.Add<Vignette>();
        v.active=true;
        v.intensity.Override(.18f);
        v.smoothness.Override(.45f);
      }
      if(enableColorGrade){
        var c=p.Add<ColorAdjustments>();
        c.active=true;
        c.postExposure.Override(.05f);
        c.contrast.Override(8f);
        c.saturation.Override(-5f);
      }
    }
  }
}
