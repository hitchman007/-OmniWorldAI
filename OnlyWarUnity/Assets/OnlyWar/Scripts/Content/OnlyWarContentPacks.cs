using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  public enum ContentPackType { HDTextures, MultiplayerMaps, BattleRoyaleMaps, Operators, Weapons, Vehicles, Audio }

  [Serializable] public sealed class OnlyWarContentPack {
    public string id;
    public ContentPackType type;
    public string url;
    public string hash;
    public long bytes;
    public bool required;
  }

  public sealed class OnlyWarContentPackManager : MonoBehaviour {
    public List<OnlyWarContentPack> catalog = new();
    public event Action<string,float> OnProgress;
    public event Action<string,string> OnFailed;
    public event Action<string> OnReady;

    public void Download(string packId) {
      var p=catalog.Find(x=>x.id==packId);
      if(p!=null)StartCoroutine(DownloadBundle(p));
    }

    IEnumerator DownloadBundle(OnlyWarContentPack p) {
      using var req=UnityWebRequestAssetBundle.GetAssetBundle(p.url);
      var op=req.SendWebRequest();
      while(!op.isDone){OnProgress?.Invoke(p.id,op.progress);yield return null;}
      if(req.result!=UnityWebRequest.Result.Success){OnFailed?.Invoke(p.id,req.error);yield break;}
      var bundle=DownloadHandlerAssetBundle.GetContent(req);
      if(!bundle){OnFailed?.Invoke(p.id,"Bundle invalid");yield break;}
      OnProgress?.Invoke(p.id,1f);OnReady?.Invoke(p.id);
    }
  }
}
