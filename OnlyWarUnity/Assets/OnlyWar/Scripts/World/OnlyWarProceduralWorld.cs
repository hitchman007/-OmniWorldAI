using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarProceduralWorld : MonoBehaviour {
    public int seed = 707;
    public int blocksX = 5;
    public int blocksZ = 5;
    public float blockSize = 42f;
    public float roadWidth = 12f;
    public OnlyWarMaterialLibrary materials;
    public bool buildOnStart = true;

    void Start(){ if(buildOnStart) Build(); }

    public void Build() {
      if (!materials) materials = FindFirstObjectByType<OnlyWarMaterialLibrary>();
      if (!materials) materials = gameObject.AddComponent<OnlyWarMaterialLibrary>();

      for(int i=transform.childCount-1;i>=0;i--) DestroyImmediateSafe(transform.GetChild(i).gameObject);

      var asphalt=materials.Get("asphalt",new Color(.08f,.09f,.095f),0f,.22f);
      var concrete=materials.Get("concrete",new Color(.42f,.42f,.39f),0f,.3f);
      var grass=materials.Get("grass",new Color(.16f,.25f,.13f),0f,.12f);
      var curb=materials.Get("curb",new Color(.52f,.51f,.47f),0f,.25f);

      float totalX=blocksX*blockSize + (blocksX+1)*roadWidth;
      float totalZ=blocksZ*blockSize + (blocksZ+1)*roadWidth;
      MakePlane("Ground",Vector3.zero,new Vector3(totalX,1,totalZ),grass);

      var rng=new System.Random(seed);
      float startX=-totalX*.5f+roadWidth*.5f;
      float startZ=-totalZ*.5f+roadWidth*.5f;

      for(int x=0;x<=blocksX;x++) {
        float px=startX+x*(blockSize+roadWidth);
        MakeBox("RoadV_"+x,new Vector3(px,.03f,0),new Vector3(roadWidth,.06f,totalZ),asphalt);
      }
      for(int z=0;z<=blocksZ;z++) {
        float pz=startZ+z*(blockSize+roadWidth);
        MakeBox("RoadH_"+z,new Vector3(0,.032f,pz),new Vector3(totalX,.06f,roadWidth),asphalt);
      }

      for(int bx=0;bx<blocksX;bx++) for(int bz=0;bz<blocksZ;bz++) {
        float cx=startX+roadWidth*.5f+blockSize*.5f+bx*(blockSize+roadWidth);
        float cz=startZ+roadWidth*.5f+blockSize*.5f+bz*(blockSize+roadWidth);
        MakeBox("BlockSlab_"+bx+"_"+bz,new Vector3(cx,.12f,cz),new Vector3(blockSize,.24f,blockSize),concrete);
        float inset=3.2f;
        MakeBox("CurbN_"+bx+"_"+bz,new Vector3(cx,.28f,cz+blockSize*.5f-inset*.3f),new Vector3(blockSize-inset,.35f,.28f),curb);
        MakeBox("CurbS_"+bx+"_"+bz,new Vector3(cx,.28f,cz-blockSize*.5f+inset*.3f),new Vector3(blockSize-inset,.35f,.28f),curb);

        int buildings=2+rng.Next(0,3);
        for(int i=0;i<buildings;i++) {
          float w=10f+(float)rng.NextDouble()*7f;
          float d=9f+(float)rng.NextDouble()*8f;
          float ox=(float)(rng.NextDouble()-.5)*(blockSize-w-5f);
          float oz=(float)(rng.NextDouble()-.5)*(blockSize-d-5f);
          int floors=1+rng.Next(1,5);
          OnlyWarBuildingFactory.CreateBlock("B_"+bx+"_"+bz+"_"+i,new Vector3(cx+ox,.25f,cz+oz),new Vector3(w,0,d),floors,materials,true,seed+bx*100+bz*10+i);
        }

        // cover/props
        for(int p=0;p<5;p++) {
          float ox=(float)(rng.NextDouble()-.5)*(blockSize-5f);
          float oz=(float)(rng.NextDouble()-.5)*(blockSize-5f);
          MakeBox("Cover_"+bx+"_"+bz+"_"+p,new Vector3(cx+ox,1f,cz+oz),new Vector3(2.8f,2f,.55f),materials.Get("cover",new Color(.20f,.23f,.24f),.1f,.32f));
        }
      }

      // tactical perimeter
      for(int i=0;i<14;i++) {
        float a=i/14f*Mathf.PI*2f;
        Vector3 p=new Vector3(Mathf.Cos(a)*totalX*.47f,.6f,Mathf.Sin(a)*totalZ*.47f);
        MakeBox("Perimeter_"+i,p,new Vector3(5f,1.2f,.7f),materials.Get("barrier",new Color(.25f,.27f,.26f),0f,.25f)).transform.rotation=Quaternion.Euler(0,-a*Mathf.Rad2Deg,0);
      }
    }

    GameObject MakePlane(string n,Vector3 pos,Vector3 scale,Material mat){
      var g=GameObject.CreatePrimitive(PrimitiveType.Plane);g.name=n;g.transform.SetParent(transform);g.transform.position=pos;g.transform.localScale=new Vector3(scale.x/10f,1,scale.z/10f);g.GetComponent<Renderer>().sharedMaterial=mat;return g;
    }
    GameObject MakeBox(string n,Vector3 pos,Vector3 scale,Material mat){
      var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name=n;g.transform.SetParent(transform);g.transform.position=pos;g.transform.localScale=scale;g.GetComponent<Renderer>().sharedMaterial=mat;return g;
    }
    static void DestroyImmediateSafe(GameObject g){if(Application.isPlaying)Destroy(g);else DestroyImmediate(g);}
  }
}
