using System.IO;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarProfileSave : MonoBehaviour {
    public OnlyWarProgression progression;
    public OnlyWarCosmeticInventory cosmetics;
    string PathName=>System.IO.Path.Combine(Application.persistentDataPath,"onlywar_profile.json");

    [System.Serializable] sealed class SaveData {
      public OnlyWarProfileData profile;
      public string[] owned;
      public string operatorSkin,weaponCamo,vehicleSkin;
      public int credits;
    }

    public void Save(){
      var d=new SaveData{
        profile=progression?progression.data:new OnlyWarProfileData(),
        owned=cosmetics?cosmetics.owned.ToArray():System.Array.Empty<string>(),
        operatorSkin=cosmetics?cosmetics.operatorSkin:"",
        weaponCamo=cosmetics?cosmetics.weaponCamo:"",
        vehicleSkin=cosmetics?cosmetics.vehicleSkin:"",
        credits=cosmetics?cosmetics.credits:0
      };
      File.WriteAllText(PathName,JsonUtility.ToJson(d,true));
    }

    public void Load(){
      if(!File.Exists(PathName))return;
      var d=JsonUtility.FromJson<SaveData>(File.ReadAllText(PathName));if(d==null)return;
      if(progression)progression.data=d.profile??new OnlyWarProfileData();
      if(cosmetics){cosmetics.owned=new System.Collections.Generic.List<string>(d.owned??System.Array.Empty<string>());cosmetics.operatorSkin=d.operatorSkin;cosmetics.weaponCamo=d.weaponCamo;cosmetics.vehicleSkin=d.vehicleSkin;cosmetics.credits=d.credits;}
    }

    void OnApplicationPause(bool p){if(p)Save();}
    void OnApplicationQuit()=>Save();
  }
}
