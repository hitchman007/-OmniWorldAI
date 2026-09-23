#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace OnlyWar.Editor {
  [InitializeOnLoad]
  public static class OnlyWarSceneBuilder {
    const string ScenePath = "Assets/OnlyWar/Scenes/OnlyWar_Main.unity";

    static OnlyWarSceneBuilder() {
      EditorApplication.delayCall += EnsureScene;
    }

    [MenuItem("OnlyWar/Build Production Bootstrap Scene")]
    public static void EnsureScene() {
      if (System.IO.File.Exists(ScenePath)) return;
      System.IO.Directory.CreateDirectory("Assets/OnlyWar/Scenes");
      var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

      var root = new GameObject("OnlyWar Systems");
      root.AddComponent<OnlyWarInput>();
      root.AddComponent<OnlyWarQuality>();
      root.AddComponent<OnlyWarModeDirector>();
      root.AddComponent<OnlyWarGame>();

      var lightGo = new GameObject("Sun");
      var light = lightGo.AddComponent<Light>();
      light.type = LightType.Directional; light.intensity = 1.4f;
      lightGo.transform.rotation = Quaternion.Euler(48f, -35f, 0f);

      var floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
      floor.name = "Combat Ground";
      floor.transform.localScale = new Vector3(20f,1f,20f);

      var player = new GameObject("Player");
      player.tag = "Player";
      player.transform.position = new Vector3(0,1,0);
      var cc = player.AddComponent<CharacterController>();
      cc.height = 1.82f; cc.radius = .36f;
      player.AddComponent<OnlyWarDamageable>().team = 0;
      var pivot = new GameObject("Camera Pivot").transform;
      pivot.SetParent(player.transform); pivot.localPosition = new Vector3(0,1.62f,0);
      var camGo = new GameObject("Main Camera");
      camGo.tag = "MainCamera"; camGo.transform.SetParent(pivot); camGo.transform.localPosition = Vector3.zero;
      var cam = camGo.AddComponent<Camera>(); cam.fieldOfView = 72f;
      var motor = player.AddComponent<OnlyWarPlayerMotor>();
      motor.input = root.GetComponent<OnlyWarInput>(); motor.viewCamera = cam; motor.cameraPivot = pivot;

      var game = root.GetComponent<OnlyWarGame>();
      game.player = motor; game.quality = root.GetComponent<OnlyWarQuality>(); game.modes = root.GetComponent<OnlyWarModeDirector>();

      EditorSceneManager.SaveScene(scene, ScenePath);
      EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(ScenePath, true) };
      AssetDatabase.SaveAssets();
      Debug.Log("OnlyWar production bootstrap scene created: " + ScenePath);
    }
  }
}
