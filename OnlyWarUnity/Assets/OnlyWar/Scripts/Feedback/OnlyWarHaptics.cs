using UnityEngine;
using UnityEngine.InputSystem;

namespace OnlyWar {
  public sealed class OnlyWarHaptics : MonoBehaviour {
    public OnlyWarPlayerSettings settings;
    float stopAt;

    void Awake(){if(!settings)settings=FindFirstObjectByType<OnlyWarPlayerSettings>();}
    public void Tap(){
      if(settings!=null&&!settings.data.haptics)return;
#if UNITY_IOS || UNITY_ANDROID
      Handheld.Vibrate();
#endif
      Rumble(.18f,.28f,.08f);
    }
    public void Shot(float strength=1f)=>Rumble(.12f*strength,.42f*strength,.06f);
    public void Explosion(float strength=1f)=>Rumble(.45f*strength,.75f*strength,.22f);
    public void Damage(float strength=.5f)=>Rumble(.28f*strength,.48f*strength,.16f);

    void Rumble(float low,float high,float seconds){
      var pad=Gamepad.current;if(pad==null)return;
      pad.SetMotorSpeeds(Mathf.Clamp01(low),Mathf.Clamp01(high));stopAt=Time.unscaledTime+seconds;
    }
    void Update(){if(stopAt>0&&Time.unscaledTime>=stopAt){Gamepad.current?.SetMotorSpeeds(0,0);stopAt=0;}}
    void OnDisable()=>Gamepad.current?.SetMotorSpeeds(0,0);
  }
}
