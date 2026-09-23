#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Unity.AI.Navigation;

namespace OnlyWar.Editor {
  [InitializeOnLoad]
  public static class OnlyWarProductionBootstrap {
    const string ScenePath="Assets/OnlyWar/Scenes/OnlyWar_ProceduralCombat.unity";

    static OnlyWarProductionBootstrap(){
      EditorApplication.delayCall+=AutoBuild;
    }

    static void AutoBuild(){
      if(System.IO.File.Exists(ScenePath))return;
      Build();
    }

    [MenuItem("OnlyWar/Build Full Procedural Combat Test")]
    public static void Build() {
      OnlyWarContentSeeder.Seed();
      var scene=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
      System.IO.Directory.CreateDirectory("Assets/OnlyWar/Scenes");

      var systems=new GameObject("OnlyWar Production");
      var mats=systems.AddComponent<OnlyWarMaterialLibrary>();
      var input=systems.AddComponent<OnlyWarInput>();
      var quality=systems.AddComponent<OnlyWarQuality>();
      systems.AddComponent<OnlyWarAdaptivePerformance>();
      var mode=systems.AddComponent<OnlyWarModeDirector>();
      var game=systems.AddComponent<OnlyWarGame>();
      systems.AddComponent<OnlyWarProceduralAudio>();
      systems.AddComponent<OnlyWarVFXFactory>();
      systems.AddComponent<OnlyWarPropFactory>().mats=mats;
      var weaponFactory=systems.AddComponent<OnlyWarProceduralWeaponFactory>();weaponFactory.materials=mats;
      var vehicleFactory=systems.AddComponent<OnlyWarVehicleFactory>();vehicleFactory.materials=mats;
      var operatorFactory=systems.AddComponent<OnlyWarOperatorFactory>();operatorFactory.materials=mats;
      systems.AddComponent<OnlyWarPlayerSettings>();
      systems.AddComponent<OnlyWarHaptics>();
      systems.AddComponent<OnlyWarProgression>();
      systems.AddComponent<OnlyWarProfileClient>();
      systems.AddComponent<OnlyWarNetDiagnostics>();

      var network=systems.AddComponent<OnlyWarHttpMatchClient>();
      network.input=input;
      var online=systems.AddComponent<OnlyWarOnlineBootstrap>();online.client=network;

      var worldGo=new GameObject("Reach-07 World");
      var world=worldGo.AddComponent<OnlyWarProceduralWorld>();world.materials=mats;world.blocksX=4;world.blocksZ=4;world.buildOnStart=false;world.Build();
      var mapDirector=systems.AddComponent<OnlyWarMapDirector>();mapDirector.world=world;mapDirector.materials=mats;mapDirector.vehicles=vehicleFactory;mapDirector.props=systems.GetComponent<OnlyWarPropFactory>();

      var surface=worldGo.AddComponent<NavMeshSurface>();surface.collectObjects=CollectObjects.All;surface.BuildNavMesh();

      var sun=new GameObject("Sun");var light=sun.AddComponent<Light>();light.type=LightType.Directional;light.intensity=1.45f;light.shadows=LightShadows.Soft;sun.transform.rotation=Quaternion.Euler(46,-32,0);
      var gfx=systems.AddComponent<OnlyWarGraphicsDirector>();gfx.sun=light;
      RenderSettings.fog=true;RenderSettings.fogColor=new Color(.53f,.58f,.59f);RenderSettings.fogDensity=.0045f;

      var player=new GameObject("Player");player.transform.position=new Vector3(6,1,6);player.tag="Player";
      var cc=player.AddComponent<CharacterController>();cc.height=1.82f;cc.radius=.35f;
      var dmg=player.AddComponent<OnlyWarDamageable>();dmg.team=0;
      var pivot=new GameObject("CameraPivot").transform;pivot.SetParent(player.transform);pivot.localPosition=new Vector3(0,1.62f,0);
      var camGo=new GameObject("Main Camera");camGo.tag="MainCamera";camGo.transform.SetParent(pivot);camGo.transform.localPosition=Vector3.zero;
      var cam=camGo.AddComponent<Camera>();cam.fieldOfView=72f;cam.nearClipPlane=.06f;
      camGo.AddComponent<AudioListener>();

      var motor=player.AddComponent<OnlyWarPlayerMotor>();motor.input=input;motor.viewCamera=cam;motor.cameraPivot=pivot;
      player.AddComponent<OnlyWarMantleSlide>().input=input;
      player.AddComponent<OnlyWarAimAssist>().input=input;
      player.AddComponent<OnlyWarGyroAim>().input=input;
      player.AddComponent<OnlyWarEquipmentController>().input=input;

      var weaponSocket=new GameObject("WeaponSocket").transform;weaponSocket.SetParent(camGo.transform);weaponSocket.localPosition=Vector3.zero;
      var fpFactory=systems.AddComponent<OnlyWarFirstPersonRigFactory>();fpFactory.materials=mats;
      var fpRig=fpFactory.Build(camGo.transform,"ARX-41");
      var weaponAnim=player.AddComponent<OnlyWarWeaponAnimator>();weaponAnim.input=input;weaponAnim.weaponRoot=fpRig.transform;

      var wc=player.AddComponent<OnlyWarWeaponController>();wc.input=input;wc.aimCamera=cam;wc.weaponSocket=weaponSocket;
      wc.loadout=new[]{
        AssetDatabase.LoadAssetAtPath<OnlyWarWeaponDefinition>("Assets/OnlyWar/Data/Weapons/ARX-41.asset"),
        AssetDatabase.LoadAssetAtPath<OnlyWarWeaponDefinition>("Assets/OnlyWar/Data/Weapons/VPR-9.asset"),
        AssetDatabase.LoadAssetAtPath<OnlyWarWeaponDefinition>("Assets/OnlyWar/Data/Weapons/HMX-7.asset")
      };
      var weaponFx=player.AddComponent<OnlyWarWeaponFX>();weaponFx.animator=weaponAnim;weaponFx.cameraRef=cam;wc.fx=weaponFx;

      game.player=motor;game.weapons=wc;game.quality=quality;game.modes=mode;
      network.localPlayer=player.transform;

      var spawnSystem=systems.AddComponent<OnlyWarSpawnSystem>();
      spawnSystem.teamA=CreateSpawns("TeamA",new[]{new Vector3(6,1,6),new Vector3(12,1,8),new Vector3(-6,1,12)});
      spawnSystem.teamB=CreateSpawns("TeamB",new[]{new Vector3(-42,1,-38),new Vector3(-32,1,-44),new Vector3(-48,1,-28)});
      mode.teamASpawns=spawnSystem.teamA;mode.teamBSpawns=spawnSystem.teamB;

      vehicleFactory.BuildMRV(new Vector3(18,0,12));
      vehicleFactory.BuildAPC(new Vector3(-20,0,-14));

      for(int i=0;i<10;i++){
        float a=i/10f*Mathf.PI*2f;
        var bot=operatorFactory.Build("HOSTILE_"+i,new Vector3(Mathf.Cos(a)*28f,0,Mathf.Sin(a)*28f),1);
        var agent=bot.AddComponent<UnityEngine.AI.NavMeshAgent>();agent.speed=3.6f;agent.angularSpeed=420f;agent.acceleration=9f;
        var ai=bot.AddComponent<OnlyWarBot>();ai.team=1;ai.eye=bot.transform.Find("Head");
        var bd=bot.GetComponent<OnlyWarDamageable>();if(bd!=null)bd.onKilled+=spawnSystem.Respawn;
      }

      var ui=systems.AddComponent<OnlyWarRuntimeUIBuilder>();ui.input=input;ui.game=game;ui.weapons=wc;ui.online=online;

      EditorSceneManager.SaveScene(scene,ScenePath);
      EditorBuildSettings.scenes=new[]{new EditorBuildSettingsScene(ScenePath,true)};
      AssetDatabase.SaveAssets();AssetDatabase.Refresh();
      Debug.Log("OnlyWar production combat scene created: "+ScenePath);
    }

    static Transform[] CreateSpawns(string name,Vector3[] positions){
      var root=new GameObject(name+" Spawns");var arr=new Transform[positions.Length];
      for(int i=0;i<positions.Length;i++){var g=new GameObject(name+"_"+i);g.transform.SetParent(root.transform);g.transform.position=positions[i];arr[i]=g.transform;}
      return arr;
    }
  }
}
