using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  public sealed class OnlyWarNetDiagnostics : MonoBehaviour {
    public string pingUrl="https://exposiqo-live-production.up.railway.app/onlywar-api/ping";
    public int pingMs;
    public bool online;
    public float interval=5f;
    public event System.Action<int,bool> OnChanged;

    void OnEnable()=>StartCoroutine(Loop());
    IEnumerator Loop(){
      while(enabled){
        float t=Time.realtimeSinceStartup;
        using var req=UnityWebRequest.Get(pingUrl);req.timeout=5;
        yield return req.SendWebRequest();
        pingMs=Mathf.RoundToInt((Time.realtimeSinceStartup-t)*1000f);
        online=req.result==UnityWebRequest.Result.Success;
        OnChanged?.Invoke(pingMs,online);
        yield return new WaitForSecondsRealtime(interval);
      }
    }
  }
}
