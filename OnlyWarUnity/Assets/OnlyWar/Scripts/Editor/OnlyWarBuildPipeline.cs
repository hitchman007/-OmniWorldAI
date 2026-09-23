#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace OnlyWar.Editor {
  public static class OnlyWarBuildPipeline {
    const string Scene="Assets/OnlyWar/Scenes/OnlyWar_ProceduralCombat.unity";
    const string Root="Builds/OnlyWar";

    [MenuItem("OnlyWar/Build/WebGL Test")]
    public static void BuildWebGL()=>Build(BuildTarget.WebGL,Root+"/WebGL",BuildOptions.None);

    [MenuItem("OnlyWar/Build/Windows x64")]
    public static void BuildWindows()=>Build(BuildTarget.StandaloneWindows64,Root+"/Windows/OnlyWar.exe",BuildOptions.None);

    [MenuItem("OnlyWar/Build/Android APK")]
    public static void BuildAndroid(){
      PlayerSettings.Android.targetArchitectures=AndroidArchitecture.ARM64;
      EditorUserBuildSettings.buildAppBundle=false;
      Build(BuildTarget.Android,Root+"/Android/OnlyWar.apk",BuildOptions.None);
    }

    [MenuItem("OnlyWar/Build/Android AAB")]
    public static void BuildAndroidBundle(){
      PlayerSettings.Android.targetArchitectures=AndroidArchitecture.ARM64;
      EditorUserBuildSettings.buildAppBundle=true;
      Build(BuildTarget.Android,Root+"/Android/OnlyWar.aab",BuildOptions.None);
    }

    [MenuItem("OnlyWar/Build/iOS Xcode")]
    public static void BuildIOS(){
      Directory.CreateDirectory(Root+"/iOS");
      Build(BuildTarget.iOS,Root+"/iOS",BuildOptions.None);
    }

    public static void CIWebGL(){OnlyWarProductionBootstrap.Build();OnlyWarBuildConfigurator.Configure();BuildWebGL();}
    public static void CIWindows(){OnlyWarProductionBootstrap.Build();OnlyWarBuildConfigurator.Configure();BuildWindows();}
    public static void CIAndroid(){OnlyWarProductionBootstrap.Build();OnlyWarBuildConfigurator.Configure();BuildAndroid();}
    public static void CIIOS(){OnlyWarProductionBootstrap.Build();OnlyWarBuildConfigurator.Configure();BuildIOS();}

    static void Build(BuildTarget target,string path,BuildOptions options){
      if(!File.Exists(Scene))OnlyWarProductionBootstrap.Build();
      OnlyWarBuildValidator.ValidateOrThrow();
      Directory.CreateDirectory(Path.GetDirectoryName(path)??Root);
      var report=BuildPipeline.BuildPlayer(new BuildPlayerOptions{
        scenes=new[]{Scene},locationPathName=path,target=target,options=options
      });
      if(report.summary.result!=BuildResult.Succeeded)
        throw new Exception($"OnlyWar {target} build failed: {report.summary.result} / {report.summary.totalErrors} errors");
      Debug.Log($"OnlyWar {target} build OK: {path} ({report.summary.totalSize} bytes)");
    }
  }
}
