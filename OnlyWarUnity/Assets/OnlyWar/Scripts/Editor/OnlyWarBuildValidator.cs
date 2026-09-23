#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace OnlyWar.Editor {
  public static class OnlyWarBuildValidator {
    public static string[] Validate(){
      var errors=new List<string>();
      const string scene="Assets/OnlyWar/Scenes/OnlyWar_ProceduralCombat.unity";
      if(!File.Exists(scene))errors.Add("Production scene missing.");
      string[] scripts={
        "Assets/OnlyWar/Scripts/Core/OnlyWarGame.cs",
        "Assets/OnlyWar/Scripts/Player/OnlyWarPlayerMotor.cs",
        "Assets/OnlyWar/Scripts/Combat/OnlyWarWeaponController.cs",
        "Assets/OnlyWar/Scripts/Networking/OnlyWarHttpMatchClient.cs",
        "Assets/OnlyWar/Scripts/UI/OnlyWarRuntimeUIBuilder.cs"
      };
      foreach(var p in scripts)if(!File.Exists(p))errors.Add("Required script missing: "+p);

      var weapons=AssetDatabase.FindAssets("t:OnlyWarWeaponDefinition",new[]{"Assets/OnlyWar/Data/Weapons"});
      if(weapons.Length<3)errors.Add("At least three production weapon definitions are required.");

      if(PlayerSettings.colorSpace!=ColorSpace.Linear)errors.Add("Linear color space is required.");
      if(EditorBuildSettings.scenes.Length==0)errors.Add("No build scene configured.");

      return errors.ToArray();
    }

    public static void ValidateOrThrow(){
      var errors=Validate();
      if(errors.Length>0)throw new Exception("OnlyWar build validation failed:\n - "+string.Join("\n - ",errors));
      Debug.Log("OnlyWar build validation PASS.");
    }

    [MenuItem("OnlyWar/Validate Production Build")]
    public static void MenuValidate()=>ValidateOrThrow();
  }
}
