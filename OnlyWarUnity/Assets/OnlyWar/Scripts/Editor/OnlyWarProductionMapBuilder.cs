#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OnlyWar.Editor {
  public static class OnlyWarProductionMapBuilder {
    static readonly string[] Names={"RiftHarbor","AetherDistrict","IronDunes"};
    static readonly Color[] Ground={new(.26f,.28f,.27f),new(.34f,.35f,.31f),new(.48f,.39f,.28f)};

    [MenuItem("OnlyWar/Generate Production Test Maps")]
    public static void BuildAll(){
      Directory.CreateDirectory("Assets/OnlyWar/Scenes");
      Directory.CreateDirectory("Assets/OnlyWar/GeneratedMaterials");
      for(int i=0;i<Names.Length;i++)BuildMap(Names[i],Ground[i],i);
      AssetDatabase.SaveAssets();
      AssetDatabase.Refresh();
    }

    static Material Mat(string name,Color c,float smooth=.25f,float metal=0f){
      string path="Assets/OnlyWar/GeneratedMaterials/"+name+".mat";
      var m=AssetDatabase.LoadAssetAtPath<Material>(path);
      if(m)return m;
      var shader=Shader.Find("Universal Render Pipeline/Lit")??Shader.Find("Standard");
      m=new Material(shader){name=name,color=c};
      if(m.HasProperty("_Smoothness"))m.SetFloat("_Smoothness",smooth);
      if(m.HasProperty("_Metallic"))m.SetFloat("_Metallic",metal);
      AssetDatabase.CreateAsset(m,path);
      return m;
    }

    static void BuildMap(string name,Color groundColor,int seed){
      var scene=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
      Random.InitState(1000+seed);
      var groundMat=Mat(name+"_Ground",groundColor,.1f);
      var roadMat=Mat(name+"_Road",new Color(.08f,.09f,.095f),.15f);
      var concrete=Mat(name+"_Concrete",new Color(.38f,.4f,.39f),.22f);
      var metal=Mat(name+"_Metal",new Color(.16f,.19f,.2f),.5f,.55f);
      var glass=Mat(name+"_Glass",new Color(.16f,.26f,.3f),.65f,.1f);

      Cube("Ground",new Vector3(0,-.5f,0),new Vector3(420,1,420),groundMat);
      for(int r=-4;r<=4;r++)Cube("Road_NS_"+r,new Vector3(r*45,.02f,0),new Vector3(12,.12f,420),roadMat);
      for(int r=-4;r<=4;r++)Cube("Road_EW_"+r,new Vector3(0,.025f,r*45),new Vector3(420,.12f,12),roadMat);

      for(int bx=-4;bx<=4;bx++)for(int bz=-4;bz<=4;bz++){
        if((bx+bz+seed)%4==0)continue;
        Vector3 center=new(bx*45+Random.Range(-7f,7f),0,bz*45+Random.Range(-7f,7f));
        BuildBlock(center,concrete,glass,metal,Random.Range(1,4));
      }

      for(int i=0;i<40;i++){
        Vector3 p=new(Random.Range(-195,195),.5f,Random.Range(-195,195));
        if(Mathf.Abs(Mathf.Repeat(p.x+22.5f,45)-22.5f)<8||Mathf.Abs(Mathf.Repeat(p.z+22.5f,45)-22.5f)<8)continue;
        Cube("Barrier_"+i,p,new Vector3(Random.Range(1.5f,4f),1f,.45f),concrete);
      }

      var sun=new GameObject("Sun");
      var l=sun.AddComponent<Light>();l.type=LightType.Directional;l.intensity=1.35f;l.shadows=LightShadows.Soft;
      sun.transform.rotation=Quaternion.Euler(48,-32,0);
      RenderSettings.fog=true;RenderSettings.fogMode=FogMode.ExponentialSquared;RenderSettings.fogDensity=.0035f;RenderSettings.fogColor=new Color(.52f,.56f,.57f);
      var fx=new GameObject("PostFX");fx.AddComponent<OnlyWarPostFX>();

      var root=new GameObject("MapSystems");
      var def=ScriptableObject.CreateInstance<OnlyWarMapDefinition>();
      def.mapId=name.ToUpperInvariant();def.displayName=ObjectNames.NicifyVariableName(name);def.biome=seed==0?"Coastal Industrial":seed==1?"Urban Civic":"Arid Military";def.supportsExtraction=true;def.supportsBattleRoyale=true;
      string defPath="Assets/OnlyWar/GeneratedMaterials/"+name+"_Definition.asset";
      AssetDatabase.CreateAsset(def,defPath);

      EditorSceneManager.SaveScene(scene,"Assets/OnlyWar/Scenes/OnlyWar_"+name+".unity");
    }

    static void BuildBlock(Vector3 c,Material wall,Material glass,Material metal,int floors){
      float w=Random.Range(17f,27f),d=Random.Range(15f,25f),h=floors*3.4f;
      // Four walls with doorway and a real interior shell.
      Cube("BuildingFloor",c+Vector3.up*.15f,new Vector3(w,.3f,d),wall);
      Cube("BackWall",c+new Vector3(0,h*.5f,d*.5f),new Vector3(w,h,.35f),wall);
      Cube("LeftWall",c+new Vector3(-w*.5f,h*.5f,0),new Vector3(.35f,h,d),wall);
      Cube("RightWall",c+new Vector3(w*.5f,h*.5f,0),new Vector3(.35f,h,d),wall);
      float door=2.2f;
      Cube("FrontWallL",c+new Vector3(-(w-door)*.25f,h*.5f,-d*.5f),new Vector3((w-door)*.5f,h,.35f),wall);
      Cube("FrontWallR",c+new Vector3((w-door)*.25f,h*.5f,-d*.5f),new Vector3((w-door)*.5f,h,.35f),wall);
      Cube("Roof",c+new Vector3(0,h,0),new Vector3(w,.3f,d),metal);
      for(int f=1;f<floors;f++)Cube("InteriorFloor",c+new Vector3(0,f*3.4f,0),new Vector3(w-.6f,.2f,d-.6f),wall);
      for(int f=0;f<floors;f++){
        float y=1.8f+f*3.4f;
        for(int x=-1;x<=1;x++)Cube("Window",c+new Vector3(x*w*.24f,y,-d*.51f),new Vector3(2.3f,1.3f,.08f),glass);
      }
      // Interior cover and stair approximation.
      Cube("InteriorCover",c+new Vector3(-w*.2f,.65f,0),new Vector3(3f,1.3f,1f),metal);
      for(int s=0;s<8;s++)Cube("Stair",c+new Vector3(w*.25f,s*.2f-0.05f,d*.15f+s*.38f),new Vector3(2.2f,.2f,.45f),wall);
    }

    static GameObject Cube(string n,Vector3 p,Vector3 s,Material m){
      var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name=n;g.transform.position=p;g.transform.localScale=s;
      if(m)g.GetComponent<Renderer>().sharedMaterial=m;return g;
    }
  }
}
