using UnityEngine;

namespace OnlyWar {
  public static class OnlyWarBuildingFactory {
    static GameObject Box(string name, Transform parent, Vector3 pos, Vector3 scale, Material mat) {
      var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
      go.name = name; go.transform.SetParent(parent); go.transform.localPosition = pos; go.transform.localScale = scale;
      if (go.TryGetComponent<Renderer>(out var r)) r.sharedMaterial = mat;
      return go;
    }

    public static GameObject CreateBlock(
      string name, Vector3 origin, Vector3 footprint, int floors,
      OnlyWarMaterialLibrary mats, bool interior = true, int seed = 1) {
      var root = new GameObject(name);
      root.transform.position = origin;
      float floorH = 3.2f;
      float height = Mathf.Max(1, floors) * floorH;

      var wallMat = mats.Get(name+"_wall", new Color(.33f,.35f,.34f),0f,.25f);
      var trimMat = mats.Get(name+"_trim", new Color(.12f,.14f,.15f),.15f,.45f);
      var glassMat = mats.Get(name+"_glass", new Color(.12f,.22f,.25f),.05f,.75f);
      var floorMat = mats.Get(name+"_floor", new Color(.19f,.18f,.16f),0f,.18f);

      float t=.28f, w=footprint.x, d=footprint.z;
      Box("NorthWall",root.transform,new Vector3(0,height*.5f,d*.5f),new Vector3(w,height,t),wallMat);
      Box("SouthWall",root.transform,new Vector3(0,height*.5f,-d*.5f),new Vector3(w,height,t),wallMat);
      Box("EastWall",root.transform,new Vector3(w*.5f,height*.5f,0),new Vector3(t,height,d),wallMat);
      Box("WestWall",root.transform,new Vector3(-w*.5f,height*.5f,0),new Vector3(t,height,d),wallMat);

      Box("Roof",root.transform,new Vector3(0,height,0),new Vector3(w,.32f,d),trimMat);
      Box("Slab",root.transform,new Vector3(0,.08f,0),new Vector3(w,.16f,d),floorMat);

      if (interior) {
        for(int f=1; f<floors; f++) Box("Floor_"+f,root.transform,new Vector3(0,f*floorH,0),new Vector3(w,.18f,d),floorMat);
        var rng = new System.Random(seed);
        for(int f=0; f<floors; f++) {
          float y=f*floorH+floorH*.5f;
          int rooms=Mathf.Clamp(Mathf.RoundToInt(w/6f),2,5);
          for(int i=1;i<rooms;i++) {
            float x=-w*.5f+(w/rooms)*i;
            Box("Partition_X_"+f+"_"+i,root.transform,new Vector3(x,y,0),new Vector3(.14f,floorH-0.18f,d*.72f),trimMat);
          }
          int corridors=Mathf.Clamp(Mathf.RoundToInt(d/8f),1,3);
          for(int i=1;i<corridors;i++) {
            float z=-d*.5f+(d/corridors)*i;
            Box("Partition_Z_"+f+"_"+i,root.transform,new Vector3(0,y,z),new Vector3(w*.74f,floorH-0.18f,.14f),trimMat);
          }
        }
        // stair core
        for(int f=0; f<floors-1; f++) {
          for(int s=0;s<7;s++) {
            var step=Box("Stair_"+f+"_"+s,root.transform,
              new Vector3(w*.32f, f*floorH + .22f + s*.42f, -d*.28f + s*.42f),
              new Vector3(2.2f,.24f,.72f),floorMat);
            step.transform.localRotation=Quaternion.identity;
          }
        }
      }

      // windows, kept non-colliding
      for(int f=0; f<floors; f++) {
        float y=f*floorH+1.75f;
        int count=Mathf.Clamp(Mathf.FloorToInt(w/3.2f),2,8);
        for(int i=0;i<count;i++) {
          float x=-w*.42f + (count==1?0:(w*.84f)*i/(count-1));
          var win=Box("Window_N_"+f+"_"+i,root.transform,new Vector3(x,y,d*.5f+.15f),new Vector3(1.25f,1.15f,.05f),glassMat);
          Object.Destroy(win.GetComponent<Collider>());
          win=Box("Window_S_"+f+"_"+i,root.transform,new Vector3(x,y,-d*.5f-.15f),new Vector3(1.25f,1.15f,.05f),glassMat);
          Object.Destroy(win.GetComponent<Collider>());
        }
      }

      // door opening visual / frame
      Box("DoorFrameL",root.transform,new Vector3(-.85f,1.2f,-d*.5f-.16f),new Vector3(.18f,2.4f,.2f),trimMat);
      Box("DoorFrameR",root.transform,new Vector3(.85f,1.2f,-d*.5f-.16f),new Vector3(.18f,2.4f,.2f),trimMat);
      Box("DoorHeader",root.transform,new Vector3(0,2.35f,-d*.5f-.16f),new Vector3(1.9f,.18f,.2f),trimMat);

      return root;
    }
  }
}
