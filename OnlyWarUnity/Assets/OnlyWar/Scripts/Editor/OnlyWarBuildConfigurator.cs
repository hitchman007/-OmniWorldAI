#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace OnlyWar.Editor {
  public static class OnlyWarBuildConfigurator {
    [MenuItem("OnlyWar/Configure Native Production Builds")]
    public static void Configure() {
      PlayerSettings.companyName = "OnlyWar";
      PlayerSettings.productName = "OnlyWar";
      PlayerSettings.colorSpace = ColorSpace.Linear;
      PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
      PlayerSettings.allowedAutorotateToLandscapeLeft = true;
      PlayerSettings.allowedAutorotateToLandscapeRight = true;
      PlayerSettings.allowedAutorotateToPortrait = false;
      PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;

      PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.iOS, "com.onlywar.game");
      PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, "com.onlywar.game");
      PlayerSettings.SetScriptingBackend(NamedBuildTarget.iOS, ScriptingImplementation.IL2CPP);
      PlayerSettings.SetScriptingBackend(NamedBuildTarget.Android, ScriptingImplementation.IL2CPP);
      PlayerSettings.SetGraphicsAPIs(BuildTarget.iOS, new[] { GraphicsDeviceType.Metal });
      PlayerSettings.SetGraphicsAPIs(BuildTarget.Android, new[] { GraphicsDeviceType.Vulkan, GraphicsDeviceType.OpenGLES3 });

      PlayerSettings.iOS.targetDevice = iOSTargetDevice.iPhoneAndiPad;
      PlayerSettings.iOS.targetOSVersionString = "15.0";
      PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;

      Debug.Log("OnlyWar configured for landscape iOS/iPadOS/Android production builds.");
    }
  }
}
