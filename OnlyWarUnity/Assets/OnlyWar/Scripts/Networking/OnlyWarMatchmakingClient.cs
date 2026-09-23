using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  [Serializable] public sealed class OnlyWarMatchTicket {
    public string id;
    public string player_id;
    public string mode;
    public string region;
    public string status;
    public string match_id;
  }

  [Serializable] public sealed class OnlyWarMatchInfo {
    public string id;
    public string mode;
    public string region;
    public string status;
    public int max_players;
    public string server_endpoint;
  }

  [Serializable] public sealed class OnlyWarMatchPlayer {
    public string player_id;
    public int team;
    public string session_token;
  }

  [Serializable] sealed class MatchmakerEnvelope {
    public OnlyWarMatchTicket ticket;
    public OnlyWarMatchInfo match;
    public OnlyWarMatchPlayer player;
    public string error;
  }

  public sealed class OnlyWarMatchmakingClient : MonoBehaviour {
    public string endpoint = "https://pvuzzvhczcnibjkjezio.supabase.co/functions/v1/onlywar-matchmaker";
    public string playerId;
    public string region = "us-east";
    public int skill;
    public float pollSeconds = 1.2f;

    public event Action<OnlyWarMatchTicket> OnQueued;
    public event Action<OnlyWarMatchInfo,OnlyWarMatchPlayer> OnMatched;
    public event Action<string> OnError;

    Coroutine pollRoutine;

    public void Queue(GameMode mode, string inputType = "touch") {
      if (string.IsNullOrWhiteSpace(playerId))
        playerId = SystemInfo.deviceUniqueIdentifier;
      if (pollRoutine != null) StopCoroutine(pollRoutine);
      StartCoroutine(QueueRoutine(mode.ToString(), inputType));
    }

    IEnumerator QueueRoutine(string mode, string inputType) {
      string body = JsonUtility.ToJson(new QueueRequest {
        action="queue", playerId=playerId, mode=mode, region=region, input=inputType, skill=skill
      });
      yield return Post(body, env => {
        if (env.ticket == null) { OnError?.Invoke(env.error ?? "Queue failed"); return; }
        OnQueued?.Invoke(env.ticket);
        if (env.ticket.status == "matched") pollRoutine = StartCoroutine(Poll());
        else pollRoutine = StartCoroutine(Poll());
      });
    }

    IEnumerator Poll() {
      while (true) {
        bool matched = false;
        string body = JsonUtility.ToJson(new StatusRequest{action="status",playerId=playerId});
        yield return Post(body, env => {
          if (!string.IsNullOrEmpty(env.error)) { OnError?.Invoke(env.error); return; }
          if (env.ticket != null && env.ticket.status == "matched" && env.match != null && env.player != null) {
            matched = true;
            OnMatched?.Invoke(env.match,env.player);
          }
        });
        if (matched) yield break;
        yield return new WaitForSecondsRealtime(pollSeconds);
      }
    }

    public void Leave() {
      if (pollRoutine != null) StopCoroutine(pollRoutine);
      pollRoutine = null;
      StartCoroutine(Post(JsonUtility.ToJson(new StatusRequest{action="leave",playerId=playerId}),_=>{}));
    }

    IEnumerator Post(string body, Action<MatchmakerEnvelope> done) {
      using var req = new UnityWebRequest(endpoint,"POST");
      req.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
      req.downloadHandler = new DownloadHandlerBuffer();
      req.SetRequestHeader("Content-Type","application/json");
      yield return req.SendWebRequest();
      if (req.result != UnityWebRequest.Result.Success) {
        OnError?.Invoke(req.error + " " + req.downloadHandler.text);
        yield break;
      }
      var env = JsonUtility.FromJson<MatchmakerEnvelope>(req.downloadHandler.text);
      done?.Invoke(env ?? new MatchmakerEnvelope{error="Invalid matchmaker response"});
    }

    [Serializable] sealed class QueueRequest {
      public string action,playerId,mode,region,input;
      public int skill;
    }
    [Serializable] sealed class StatusRequest {
      public string action,playerId;
    }
  }
}
