using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarMaterialLibrary : MonoBehaviour {
    readonly Dictionary<string, Material> cache = new();

    public Material Get(string id, Color color, float metallic = 0f, float smoothness = .4f) {
      if (cache.TryGetValue(id, out var existing)) return existing;
      Shader shader = Shader.Find("Universal Render Pipeline/Lit");
      if (!shader) shader = Shader.Find("Standard");
      var m = new Material(shader) { name = "OW_" + id };
      if (m.HasProperty("_BaseColor")) m.SetColor("_BaseColor", color);
      else if (m.HasProperty("_Color")) m.color = color;
      if (m.HasProperty("_Metallic")) m.SetFloat("_Metallic", metallic);
      if (m.HasProperty("_Smoothness")) m.SetFloat("_Smoothness", smoothness);
      cache[id] = m;
      return m;
    }
  }
}
