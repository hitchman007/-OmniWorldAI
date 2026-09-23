using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  [Serializable] public sealed class OWChatMessage {
    public int seq;
    public double time;
    public string playerId;
    public int team;
    public string text;
  }
  [Serializable] sealed class OWChatList { public OWChatMessage[] messages; }
  [Serializable] sealed class OWChatPost { public string ticket; public string text; }

  public sealed class OnlyWarTextChatClient : MonoBehaviour {
    public OnlyWarHttpMatchClient match;
    public string apiBase="https://exposiqo-live-production.up.railway.app/onlywar-api";
    public float pollSeconds=.6f;
    public event Action<OWChatMessage> OnMessage;
    int lastSeq;
    bool running;

    void Awake(){if(!match)match=FindFirstObjectByType<OnlyWarHttpMatchClient>();}
    void OnEnable(){running=true;StartCoroutine(Poll());}
    void OnDisable()=>running=false;

    public void Send(string text){
      text=(text??"").Trim();if(string.IsNullOrEmpty(text)||match==null||string.IsNullOrEmpty(match.ticket))return;
      StartCoroutine(SendRoutine(text.Length>180?text.Substring(0,180):text));
    }

    IEnumerator SendRoutine(string text){
      var body=JsonUtility.ToJson(new OWChatPost{ticket=match.ticket,text=text});
      using var req=Post(apiBase+"/chat",body);yield return req.SendWebRequest();
    }

    IEnumerator Poll(){
      while(running){
        if(match!=null&&match.status=="matched"&&!string.IsNullOrEmpty(match.ticket)){
          using var req=UnityWebRequest.Get(apiBase+"/chat?ticket="+UnityWebRequest.EscapeURL(match.ticket)+"&after="+lastSeq);req.timeout=5;
          yield return req.SendWebRequest();
          if(req.result==UnityWebRequest.Result.Success){
            var list=JsonUtility.FromJson<OWChatList>(req.downloadHandler.text);
            if(list?.messages!=null)foreach(var m in list.messages){lastSeq=Mathf.Max(lastSeq,m.seq);OnMessage?.Invoke(m);}
          }
        }
        yield return new WaitForSecondsRealtime(pollSeconds);
      }
    }

    static UnityWebRequest Post(string url,string json){
      var r=new UnityWebRequest(url,"POST");r.uploadHandler=new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));r.downloadHandler=new DownloadHandlerBuffer();r.SetRequestHeader("Content-Type","application/json");r.timeout=5;return r;
    }
  }
}
