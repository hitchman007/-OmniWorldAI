using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarProceduralTextures : MonoBehaviour {
    public int size=256;
    public Texture2D Asphalt(int seed=1)=>NoiseTexture("OW_Asphalt",new Color(.11f,.115f,.12f),.16f,18f,seed);
    public Texture2D Concrete(int seed=2)=>NoiseTexture("OW_Concrete",new Color(.46f,.45f,.42f),.13f,10f,seed);
    public Texture2D Dirt(int seed=3)=>NoiseTexture("OW_Dirt",new Color(.24f,.18f,.11f),.20f,8f,seed);
    public Texture2D Fabric(int seed=4)=>NoiseTexture("OW_Fabric",new Color(.10f,.12f,.12f),.09f,34f,seed);
    public Texture2D Metal(int seed=5)=>NoiseTexture("OW_Metal",new Color(.16f,.18f,.19f),.08f,5f,seed);

    Texture2D NoiseTexture(string name,Color baseColor,float variation,float scale,int seed){
      var tex=new Texture2D(size,size,TextureFormat.RGBA32,true,true){name=name,wrapMode=TextureWrapMode.Repeat,filterMode=FilterMode.Trilinear};
      var colors=new Color[size*size];
      float ox=seed*17.713f,oy=seed*31.119f;
      for(int y=0;y<size;y++)for(int x=0;x<size;x++){
        float n=Mathf.PerlinNoise(ox+x/(float)size*scale,oy+y/(float)size*scale);
        float fine=Mathf.PerlinNoise(ox*2+x/(float)size*scale*4f,oy*2+y/(float)size*scale*4f);
        float v=(n-.5f)*variation+(fine-.5f)*variation*.35f;
        colors[y*size+x]=new Color(Mathf.Clamp01(baseColor.r+v),Mathf.Clamp01(baseColor.g+v),Mathf.Clamp01(baseColor.b+v),1);
      }
      tex.SetPixels(colors);tex.Apply(true,false);return tex;
    }
  }
}
