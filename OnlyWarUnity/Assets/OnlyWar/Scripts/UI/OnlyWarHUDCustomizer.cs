using System;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  [Serializable] public sealed class OnlyWarHudElementState {
    public string id;
    public Vector2 anchoredPosition;
    public Vector2 size;
    public float alpha = 1f;
    public float scale = 1f;
  }

  [Serializable] public sealed class OnlyWarHudLayoutData {
    public List<OnlyWarHudElementState> elements = new();
  }

  public sealed class OnlyWarHUDCustomizer : MonoBehaviour {
    public RectTransform hudRoot;
    const string Key = "onlywar.hud.layout.v1";

    public void Save() {
      if (!hudRoot) return;
      var data = new OnlyWarHudLayoutData();
      foreach (RectTransform t in hudRoot) {
        var group=t.GetComponent<CanvasGroup>();
        data.elements.Add(new OnlyWarHudElementState {
          id=t.name, anchoredPosition=t.anchoredPosition, size=t.sizeDelta,
          alpha=group?group.alpha:1f, scale=t.localScale.x
        });
      }
      PlayerPrefs.SetString(Key,JsonUtility.ToJson(data));
      PlayerPrefs.Save();
    }

    public void Load() {
      if (!hudRoot || !PlayerPrefs.HasKey(Key)) return;
      var data=JsonUtility.FromJson<OnlyWarHudLayoutData>(PlayerPrefs.GetString(Key));
      if(data?.elements==null)return;
      foreach(var s in data.elements){
        var t=hudRoot.Find(s.id) as RectTransform;
        if(!t)continue;
        t.anchoredPosition=s.anchoredPosition; t.sizeDelta=s.size; t.localScale=Vector3.one*s.scale;
        var g=t.GetComponent<CanvasGroup>(); if(g)g.alpha=s.alpha;
      }
    }

    public void ResetLayout(){PlayerPrefs.DeleteKey(Key);}
  }
}
