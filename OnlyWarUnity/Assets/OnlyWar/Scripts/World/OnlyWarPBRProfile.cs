using UnityEngine;

namespace OnlyWar {
  [CreateAssetMenu(menuName="OnlyWar/PBR Surface Profile")]
  public sealed class OnlyWarPBRProfile : ScriptableObject {
    public Texture2D albedo;
    public Texture2D normal;
    public Texture2D maskMap;
    [Range(0,1)] public float metallic;
    [Range(0,1)] public float smoothness=.45f;
    public float normalScale=1f;
    public Vector2 tiling=Vector2.one;

    public void Apply(Material m){
      if(!m)return;
      if(albedo)m.SetTexture("_BaseMap",albedo);
      if(normal)m.SetTexture("_BumpMap",normal);
      if(maskMap)m.SetTexture("_MaskMap",maskMap);
      m.SetFloat("_Metallic",metallic);
      m.SetFloat("_Smoothness",smoothness);
      m.SetFloat("_BumpScale",normalScale);
      m.SetTextureScale("_BaseMap",tiling);
    }
  }
}
