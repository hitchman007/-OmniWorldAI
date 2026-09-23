#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace OnlyWar.Editor {
  public static class OnlyWarBuildPipeline {
    static string[] Scenes(){
      string[] preferred={
        "Assets/OnlyWar/Scenes/OnlyWar_RiftHarbor.unity",
        "Assets/OnlyWar/Scenes/OnlyWar_AetherDistrict.unity",
        "Assets/OnlyWar/Scenes/OnlyWar_IronDunes.unity",
        "Assets/OnlyWar/Scenes/OnlyWar_Main.unity"
      };
      foreach(var s in preferred)if(File.Exists(s))return new[]{s};
      return Array.ConvertAll(EditorBuildSettings.scenes,x=>x.path);
    }

    [MenuItem("OnlyWar/Build/Windows Test")]
    public static void Windows()=>Build(BuildTarget.StandaloneWindows64,"Builds/Windows/OnlyWar.exe");

    [MenuItem("OnlyWar/Build/WebGL Test")]
    public static void WebGL()=>Build(BuildTarget.WebGL,"Builds/WebGL");

    [MenuItem("OnlyWar/Build/Android APK")]
    public static void Android()=>Build(BuildTarget.Android,"Builds/Android/OnlyWar.apk");

    [MenuItem("OnlyWar/Build/iOS Xcode")]
    public static void IOS()=>Build(BuildTarget.iOS,"Builds/iOS");

    public static void CIWebGL()=>WebGL();
    public static void CIWindows()=>Windows();
    public static void CIAndroid()=>Android();

    static void Build(BuildTarget target,string path){
      Directory.CreateDirectory(Path.GetDirectoryName(path)??path);
      var o=new BuildPlayerOptions{scenes=Scenes(),locationPathName=path,target=target,options=BuildOptions.None};
      BuildReport r=BuildPipeline.BuildPlayer(o);
      Debug.Log($"OnlyWar build {target}: {r.summary.result} size={r.summary.totalSize} warnings={r.summary.totalWarnings} errors={r.summary.totalErrors}");
      if(r.summary.result!=BuildResult.Succeeded)throw new Exception("OnlyWar build failed: "+r.summary.result);
    }
  }
}
