#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace OnlyWar.Editor {
  public static class OnlyWarProductionBootstrap {
    [MenuItem("OnlyWar/Build Full Procedural Combat Test")]
    public static void Build() {
      var scene=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
      var systems=new GameObject("OnlyWar Production");
      var mats=systems.AddComponent<OnlyWarMaterialLibrary>();
      var input=systems.AddComponent<OnlyWarInput>();
      systems.AddComponent<OnlyWarQuality>();
      var mode=systems.AddComponent<OnlyWarModeDirector>();
      var game=systems.AddComponent<OnlyWarGame>();
      var audio=systems.AddComponent<OnlyWarProceduralAudio>();
      var vfx=systems.AddComponent<OnlyWarVFXFactory>();
      var weaponFactory=systems.AddComponent<OnlyWarProceduralWeaponFactory>();weaponFactory.materials=mats;
      var vehicleFactory=systems.AddComponent<OnlyWarVehicleFactory>();vehicleFactory.materials=mats;
      var operatorFactory=systems.AddComponent<OnlyWarOperatorFactory>();operatorFactory.materials=mats;

      var worldGo=new GameObject("Reach-07 World");
      var world=worldGo.AddComponent<OnlyWarProceduralWorld>();world.materials=mats;world.blocksX=4;world.blocksZ=4;world.buildOnStart=false;world.Build();

      var sun=new GameObject("Sun");var light=sun.AddComponent<Light>();light.type=LightType.Directional;light.intensity=1.45f;light.shadows=LightShadows.Soft;sun.transform.rotation=Quaternion.Euler(46,-32,0);
      RenderSettings.fog=true;RenderSettings.fogColor=new Color(.53f,.58f,.59f);RenderSettings.fogDensity=.0045f;

      var player=new GameObject("Player");player.transform.position=new Vector3(6,1,6);player.tag="Player";
      var cc=player.AddComponent<CharacterController>();cc.height=1.82f;cc.radius=.35f;
      var dmg=player.AddComponent<OnlyWarDamageable>();dmg.team=0;
      var pivot=new GameObject("CameraPivot").transform;pivot.SetParent(player.transform);pivot.localPosition=new Vector3(0,1.62f,0);
      var camGo=new GameObject("Main Camera");camGo.tag="MainCamera";camGo.transform.SetParent(pivot);camGo.transform.localPosition=Vector3.zero;
      var cam=camGo.AddComponent<Camera>();cam.fieldOfView=72f;cam.nearClipPlane=.06f;
      var motor=player.AddComponent<OnlyWarPlayerMotor>();motor.input=input;motor.viewCamera=cam;motor.cameraPivot=pivot;
      var socket=new GameObject("WeaponSocket").transform;socket.SetParent(camGo.transform);socket.localPosition=Vector3.zero;
      var weapon=weaponFactory.Build("ARX-41");weapon.transform.SetParent(socket,false);
      var animator=player.AddComponent<OnlyWarWeaponAnimator>();animator.input=input;animator.weaponRoot=weapon.transform;

      game.player=motor;game.quality=systems.GetComponent<OnlyWarQuality>();game.modes=mode;

      vehicleFactory.BuildMRV(new Vector3(18,0,12));
      vehicleFactory.BuildAPC(new Vector3(-20,0,-14));

      for(int i=0;i<10;i++){
        float a=i/10f*Mathf.PI*2f;
        var bot=operatorFactory.Build("HOSTILE_"+i,new Vector3(Mathf.Cos(a)*28f,0,Mathf.Sin(a)*28f),1);
        var agent=bot.AddComponent<UnityEngine.AI.NavMeshAgent>();agent.speed=3.6f;agent.angularSpeed=420f;
        var ai=bot.AddComponent<OnlyWarBot>();ai.team=1;ai.eye=bot.transform.Find("Head");
      }

      System.IO.Directory.CreateDirectory("Assets/OnlyWar/Scenes");
      EditorSceneManager.SaveScene(scene,"Assets/OnlyWar/Scenes/OnlyWar_ProceduralCombat.unity");
      AssetDatabase.SaveAssets();
      Debug.Log("OnlyWar full procedural combat test scene created.");
    }
  }
}
