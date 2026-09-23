using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  [Serializable] public sealed class OnlyWarProfileResponse {
    public string player_id;
    public string display_name;
    public int level;
    public int xp;
    public int credits;
    public int ranked_points;
    public long kills,deaths,wins,losses,matches;
  }

  public sealed class OnlyWarProfileClient : MonoBehaviour {
    public string apiBase="https://exposiqo-live-production.up.railway.app/onlywar-api";
    public string playerId;
    public OnlyWarProfileResponse profile;
    public event Action<OnlyWarProfileResponse> OnLoaded;
    public event Action<string> OnError;

    void Awake(){if(string.IsNullOrEmpty(playerId))playerId=SystemInfo.deviceUniqueIdentifier+"-"+UnityEngine.Random.Range(100,999);}
    public void Load()=>StartCoroutine(Routine());
    IEnumerator Routine(){
      using var req=UnityWebRequest.Get(apiBase+"/profile?playerId="+UnityWebRequest.EscapeURL(playerId));req.timeout=10;
      yield return req.SendWebRequest();
      if(req.result!=UnityWebRequest.Result.Success){OnError?.Invoke(req.error);yield break;}
      profile=JsonUtility.FromJson<OnlyWarProfileResponse>(req.downloadHandler.text);
      if(profile==null){OnError?.Invoke("Invalid profile");yield break;}
      OnLoaded?.Invoke(profile);
    }
  }
}
