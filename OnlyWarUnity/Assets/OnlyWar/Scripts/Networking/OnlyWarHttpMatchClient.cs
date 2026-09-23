using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  [Serializable] public sealed class OWQueueRequest { public string playerId; public string mode; }
  [Serializable] public sealed class OWTicketResponse {
    public string ticket;
    public string playerId;
    public string status;
    public string roomId;
    public int team;
    public string mode;
    public int players;
    public int tick;
  }
  [Serializable] public sealed class OWInputRequest {
    public string ticket;
    public float mx, my, look;
    public int buttons;
  }
  [Serializable] public sealed class OWSnapshotPlayer {
    public string id;
    public float x,z,yaw,hp,armor;
    public int score;
  }
  [Serializable] public sealed class OWStateResponse {
    public string roomId;
    public int tick;
    public OWSnapshotPlayer[] players;
  }

  public sealed class OnlyWarHttpMatchClient : MonoBehaviour {
    public string apiBase = "https://exposiqo-live-production.up.railway.app/onlywar-api";
    public string playerId;
    public string ticket;
    public string roomId;
    public string status;
    public int team;
    public int serverTick;
    public float sendRate = 20f;
    public float stateRate = 15f;

    public OnlyWarInput input;
    public Transform localPlayer;
    public GameObject remotePlayerPrefab;

    public event Action<OWTicketResponse> OnTicket;
    public event Action<OWStateResponse> OnState;
    public event Action<string> OnError;

    float sendClock, stateClock;
    GameObject remote;

    void Awake() {
      if (string.IsNullOrWhiteSpace(playerId))
        playerId = SystemInfo.deviceUniqueIdentifier + "-" + UnityEngine.Random.Range(100,999);
      if (!input) input = FindFirstObjectByType<OnlyWarInput>();
      if (!localPlayer) {
        var p=FindFirstObjectByType<OnlyWarPlayerMotor>();
        if(p)localPlayer=p.transform;
      }
    }

    public void Queue(string mode) => StartCoroutine(QueueRoutine(mode));

    IEnumerator QueueRoutine(string mode) {
      var payload = new OWQueueRequest { playerId = playerId, mode = mode };
      using var req = JsonPost(apiBase + "/queue", JsonUtility.ToJson(payload));
      yield return req.SendWebRequest();
      if (req.result != UnityWebRequest.Result.Success) { OnError?.Invoke(req.error); yield break; }
      var t = JsonUtility.FromJson<OWTicketResponse>(req.downloadHandler.text);
      ApplyTicket(t);
      if (status == "waiting") StartCoroutine(PollTicket());
    }

    IEnumerator PollTicket() {
      while (status == "waiting") {
        yield return new WaitForSeconds(1f);
        using var req=UnityWebRequest.Get(apiBase + "/ticket?ticket=" + UnityWebRequest.EscapeURL(ticket));
        yield return req.SendWebRequest();
        if(req.result!=UnityWebRequest.Result.Success){OnError?.Invoke(req.error);continue;}
        var t=JsonUtility.FromJson<OWTicketResponse>(req.downloadHandler.text);
        ApplyTicket(t);
      }
    }

    void ApplyTicket(OWTicketResponse t) {
      if(t==null)return;
      ticket=t.ticket;roomId=t.roomId;status=t.status;team=t.team;serverTick=t.tick;
      OnTicket?.Invoke(t);
    }

    void Update() {
      if (status != "matched" || string.IsNullOrEmpty(ticket) || input == null) return;
      sendClock += Time.deltaTime;
      stateClock += Time.deltaTime;
      if (sendClock >= 1f/Mathf.Max(1f,sendRate)) { sendClock=0f; StartCoroutine(SendInput()); }
      if (stateClock >= 1f/Mathf.Max(1f,stateRate)) { stateClock=0f; StartCoroutine(PullState()); }
    }

    IEnumerator SendInput() {
      int buttons = (input.FireHeld?1:0) | (input.SprintHeld?2:0) | (input.AdsHeld?4:0);
      var p=new OWInputRequest{ticket=ticket,mx=input.Move.x,my=input.Move.y,look=input.Look.x,buttons=buttons};
      using var req=JsonPost(apiBase+"/input",JsonUtility.ToJson(p));
      yield return req.SendWebRequest();
      if(req.result!=UnityWebRequest.Result.Success)OnError?.Invoke(req.error);
    }

    IEnumerator PullState() {
      using var req=UnityWebRequest.Get(apiBase+"/state?ticket="+UnityWebRequest.EscapeURL(ticket));
      yield return req.SendWebRequest();
      if(req.result!=UnityWebRequest.Result.Success){OnError?.Invoke(req.error);yield break;}
      var s=JsonUtility.FromJson<OWStateResponse>(req.downloadHandler.text);
      if(s==null)return;
      serverTick=s.tick;OnState?.Invoke(s);ApplyState(s);
    }

    void ApplyState(OWStateResponse s) {
      if(s.players==null)return;
      foreach(var p in s.players) {
        if(p.id==playerId) {
          if(localPlayer) {
            var authoritative=new Vector3(p.x,localPlayer.position.y,p.z);
            if(Vector3.Distance(localPlayer.position,authoritative)>2.5f) localPlayer.position=Vector3.Lerp(localPlayer.position,authoritative,.55f);
          }
          continue;
        }
        if(!remote && remotePlayerPrefab) remote=Instantiate(remotePlayerPrefab);
        if(!remote) continue;
        var target=new Vector3(p.x,remote.transform.position.y,p.z);
        remote.transform.position=Vector3.Lerp(remote.transform.position,target,12f*Time.deltaTime);
        remote.transform.rotation=Quaternion.Slerp(remote.transform.rotation,Quaternion.Euler(0,p.yaw*Mathf.Rad2Deg,0),12f*Time.deltaTime);
      }
    }

    static UnityWebRequest JsonPost(string url,string json) {
      var req=new UnityWebRequest(url,"POST");
      req.uploadHandler=new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
      req.downloadHandler=new DownloadHandlerBuffer();
      req.SetRequestHeader("Content-Type","application/json");
      req.timeout=10;
      return req;
    }
  }
}
