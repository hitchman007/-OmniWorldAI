using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  [Serializable] public sealed class MatchTicketRequest {
    public string playerId;
    public string mode;
    public string region;
    public string input;
    public int skill;
  }

  [Serializable] public sealed class MatchTicketResponse {
    public string matchId;
    public string endpoint;
    public string token;
    public int team;
  }

  public sealed class OnlyWarMatchmaking : MonoBehaviour {
    public string apiBase = "https://replace-with-onlywar-api";
    public event Action<MatchTicketResponse> OnMatched;
    public event Action<string> OnError;

    public void Queue(MatchTicketRequest request)=>StartCoroutine(QueueRoutine(request));

    IEnumerator QueueRoutine(MatchTicketRequest request){
      string json=JsonUtility.ToJson(request);
      using var req=new UnityWebRequest(apiBase+"/match/queue","POST");
      req.uploadHandler=new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
      req.downloadHandler=new DownloadHandlerBuffer();
      req.SetRequestHeader("Content-Type","application/json");
      yield return req.SendWebRequest();
      if(req.result!=UnityWebRequest.Result.Success){OnError?.Invoke(req.error);yield break;}
      var response=JsonUtility.FromJson<MatchTicketResponse>(req.downloadHandler.text);
      OnMatched?.Invoke(response);
    }
  }
}
