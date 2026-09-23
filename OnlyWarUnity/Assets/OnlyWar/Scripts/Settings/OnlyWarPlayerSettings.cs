using UnityEngine;

namespace OnlyWar {
  [System.Serializable]
  public sealed class OnlyWarSettingsData {
    public float lookSensitivity=1f;
    public float adsSensitivity=.72f;
    public float fov=72f;
    public float masterVolume=1f;
    public float musicVolume=.7f;
    public float effectsVolume=1f;
    public float voiceVolume=1f;
    public bool aimAssist=true;
    public bool gyro=false;
    public bool haptics=true;
    public bool autoSprint=false;
    public QualityTier quality=QualityTier.High;
  }

  public sealed class OnlyWarPlayerSettings : MonoBehaviour {
    public OnlyWarSettingsData data=new();
    public OnlyWarQuality quality;
    const string Key="onlywar.settings.v2";

    void Awake(){Load();Apply();}
    public void Save(){PlayerPrefs.SetString(Key,JsonUtility.ToJson(data));PlayerPrefs.Save();}
    public void Load(){if(PlayerPrefs.HasKey(Key))data=JsonUtility.FromJson<OnlyWarSettingsData>(PlayerPrefs.GetString(Key))??new OnlyWarSettingsData();}
    public void Apply(){
      if(!quality)quality=FindFirstObjectByType<OnlyWarQuality>();quality?.Apply(data.quality);
      AudioListener.volume=Mathf.Clamp01(data.masterVolume);
      var p=FindFirstObjectByType<OnlyWarPlayerMotor>();
      if(p&&p.viewCamera)p.viewCamera.fieldOfView=Mathf.Clamp(data.fov,60,90);
    }
    public void ResetDefaults(){data=new OnlyWarSettingsData();Apply();Save();}
  }
}
