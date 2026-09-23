using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  [Serializable] public sealed class OnlyWarPeerState {
    public string player_id;
    public long seq;
    public float px,py,pz,yaw,pitch,vx,vy,vz,health,armor;
    public int stance;
    public string weapon;
  }

  [Serializable] sealed class SessionEnvelope {
    public bool ok;
    public long serverTime;
    public int team;
    public OnlyWarPeerState[] peers;
    public string error;
  }

  [Serializable] sealed class SessionStatePayload {
    public long seq;
    public float px,py,pz,yaw,pitch,vx,vy,vz,health=100,armor=100;
    public int stance;
    public string weapon="ARX-41";
  }

  [Serializable] sealed class SessionRequest {
    public string matchId,playerId,sessionToken,action;
    public SessionStatePayload state;
  }

  public sealed class OnlyWarSessionRelay : MonoBehaviour {
    public string endpoint = "https://pvuzzvhczcnibjkjezio.supabase.co/functions/v1/onlywar-session";
    public Transform localPlayer;
    public Rigidbody localBody;
    public OnlyWarDamageable localDamageable;
    public OnlyWarWeaponController weapons;
    public float sendHz = 12f;
    public float interpolation = 14f;
    public GameObject remotePlayerPrefab;

    public string MatchId { get; private set; }
    public string PlayerId { get; private set; }
    public string SessionToken { get; private set; }
    public int Team { get; private set; }

    readonly Dictionary<string,RemoteAvatar> remotes = new();
    Coroutine loop;
    long seq;

    public void Begin(OnlyWarMatchInfo match, OnlyWarMatchPlayer player) {
      MatchId=match.id; PlayerId=player.player_id; SessionToken=player.session_token; Team=player.team;
      if(loop!=null)StopCoroutine(loop);
      loop=StartCoroutine(SyncLoop());
    }

    IEnumerator SyncLoop() {
      var wait=new WaitForSecondsRealtime(1f/Mathf.Max(1f,sendHz));
      while(!string.IsNullOrEmpty(MatchId)) {
        yield return Push();
        yield return wait;
      }
    }

    IEnumerator Push() {
      if(!localPlayer)yield break;
      var e=localPlayer.eulerAngles;
      var v=localBody?localBody.linearVelocity:Vector3.zero;
      var d=localDamageable;
      var payload=new SessionRequest{
        matchId=MatchId,playerId=PlayerId,sessionToken=SessionToken,
        state=new SessionStatePayload{
          seq=++seq,px=localPlayer.position.x,py=localPlayer.position.y,pz=localPlayer.position.z,
          yaw=e.y,pitch=e.x,vx=v.x,vy=v.y,vz=v.z,
          health=d?d.Health01*100f:100f,armor=d?d.armor:100f,
          stance=0,weapon=weapons&&weapons.Current?weapons.Current.weaponId:"ARX-41"
        }
      };
      string body=JsonUtility.ToJson(payload);
      using var req=new UnityWebRequest(endpoint,"POST");
      req.uploadHandler=new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
      req.downloadHandler=new DownloadHandlerBuffer();
      req.SetRequestHeader("Content-Type","application/json");
      yield return req.SendWebRequest();
      if(req.result!=UnityWebRequest.Result.Success)yield break;
      var env=JsonUtility.FromJson<SessionEnvelope>(req.downloadHandler.text);
      if(env==null||!env.ok)return;
      Team=env.team;
      ApplyPeers(env.peers);
    }

    void ApplyPeers(OnlyWarPeerState[] peers) {
      var seen=new HashSet<string>();
      if(peers!=null)foreach(var p in peers){
        seen.Add(p.player_id);
        if(!remotes.TryGetValue(p.player_id,out var a)){
          var go=remotePlayerPrefab?Instantiate(remotePlayerPrefab):GameObject.CreatePrimitive(PrimitiveType.Capsule);
          go.name="Remote_"+p.player_id;
          a=new RemoteAvatar{root=go.transform};
          remotes[p.player_id]=a;
        }
        a.targetPos=new Vector3(p.px,p.py,p.pz);
        a.targetRot=Quaternion.Euler(0,p.yaw,0);
        a.lastSeen=Time.unscaledTime;
      }
      foreach(var kv in remotes) {
        if(Time.unscaledTime-kv.Value.lastSeen>10f)kv.Value.root.gameObject.SetActive(false);
        else kv.Value.root.gameObject.SetActive(true);
      }
    }

    void Update() {
      foreach(var a in remotes.Values){
        if(!a.root||!a.root.gameObject.activeSelf)continue;
        float t=1f-Mathf.Exp(-interpolation*Time.deltaTime);
        a.root.position=Vector3.Lerp(a.root.position,a.targetPos,t);
        a.root.rotation=Quaternion.Slerp(a.root.rotation,a.targetRot,t);
      }
    }

    public void Leave() {
      if(string.IsNullOrEmpty(MatchId))return;
      StartCoroutine(LeaveRoutine());
    }

    IEnumerator LeaveRoutine() {
      var payload=new SessionRequest{matchId=MatchId,playerId=PlayerId,sessionToken=SessionToken,action="leave"};
      using var req=new UnityWebRequest(endpoint,"POST");
      req.uploadHandler=new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(payload)));
      req.downloadHandler=new DownloadHandlerBuffer();
      req.SetRequestHeader("Content-Type","application/json");
      yield return req.SendWebRequest();
      MatchId=PlayerId=SessionToken=null;
      if(loop!=null)StopCoroutine(loop);
      loop=null;
    }

    sealed class RemoteAvatar {
      public Transform root;
      public Vector3 targetPos;
      public Quaternion targetRot;
      public float lastSeen;
    }
  }
}
