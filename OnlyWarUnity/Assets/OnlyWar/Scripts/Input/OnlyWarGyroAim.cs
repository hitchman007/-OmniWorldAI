using UnityEngine;
using UnityEngine.InputSystem;

namespace OnlyWar {
  public sealed class OnlyWarGyroAim : MonoBehaviour {
    public OnlyWarInput input;
    public OnlyWarPlayerSettings settings;
    public float sensitivity=1.4f;

    void Awake(){
      if(!input)input=FindFirstObjectByType<OnlyWarInput>();
      if(!settings)settings=FindFirstObjectByType<OnlyWarPlayerSettings>();
      if(Gyroscope.current!=null)InputSystem.EnableDevice(Gyroscope.current);
    }

    void Update(){
      if(!input||settings==null||!settings.data.gyro||Gyroscope.current==null)return;
      Vector3 rate=Gyroscope.current.angularVelocity.ReadValue();
      input.AddMobileLook(new Vector2(-rate.y,rate.x)*sensitivity);
    }
  }
}
