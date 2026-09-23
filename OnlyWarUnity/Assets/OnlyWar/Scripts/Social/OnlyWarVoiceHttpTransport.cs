using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace OnlyWar {
  [Serializable] sealed class OWVoicePost {
    public string ticket;
    public int sampleRate;
    public string data;
  }
  [Serializable] sealed class OWVoiceChunk {
    public int seq;
    public double time;
    public string playerId;
    public int sampleRate;
    public string data;
  }
  [Serializable] sealed class OWVoiceList { public OWVoiceChunk[] chunks; }

  public sealed class OnlyWarVoiceHttpTransport : MonoBehaviour, IOnlyWarVoiceTransport {
    public OnlyWarHttpMatchClient match;
    public string apiBase="https://exposiqo-live-production.up.railway.app/onlywar-api";
    public int sampleRate=16000;
    public float chunkSeconds=.25f;
    public bool Connected=>match!=null&&match.status=="matched";
    public bool muted;
    public bool pushToTalk;
    public bool transmit;
    public AudioSource playback;

    AudioClip mic;
    int lastMicPos;
    int lastRemoteSeq;
    bool running;
    string channelId;

    void Awake(){
      if(!match)match=FindFirstObjectByType<OnlyWarHttpMatchClient>();
      if(!playback)playback=gameObject.AddComponent<AudioSource>();
      playback.spatialBlend=0f;playback.playOnAwake=false;
    }

    void OnEnable(){running=true;StartCoroutine(CaptureLoop());StartCoroutine(PullLoop());}
    void OnDisable(){running=false;StopMic();}
    public void JoinChannel(string channel){channelId=channel;StartMic();}
    public void LeaveChannel(){channelId=null;StopMic();}
    public void SetMuted(bool value){muted=value;}
    public void SetPushToTalk(bool enabled){pushToTalk=enabled;}

    public void SetTransmit(bool value){transmit=value;if(value)StartMic();}

    void StartMic(){
      if(mic||Microphone.devices.Length==0)return;
      mic=Microphone.Start(null,true,1,sampleRate);lastMicPos=0;
    }
    void StopMic(){if(mic){Microphone.End(null);mic=null;lastMicPos=0;}}

    IEnumerator CaptureLoop(){
      var wait=new WaitForSecondsRealtime(chunkSeconds);
      while(running){
        yield return wait;
        if(!Connected||muted||(pushToTalk&&!transmit)){lastMicPos=mic?Microphone.GetPosition(null):0;continue;}
        if(!mic)StartMic();if(!mic)continue;
        int pos=Microphone.GetPosition(null);if(pos<0||pos==lastMicPos)continue;
        float[] samples=ReadCircular(mic,lastMicPos,pos);lastMicPos=pos;
        if(samples.Length==0)continue;
        byte[] pcm=FloatToPcm16(samples);
        var body=JsonUtility.ToJson(new OWVoicePost{ticket=match.ticket,sampleRate=sampleRate,data=Convert.ToBase64String(pcm)});
        using var req=Post(apiBase+"/voice",body);yield return req.SendWebRequest();
      }
    }

    IEnumerator PullLoop(){
      var wait=new WaitForSecondsRealtime(.22f);
      while(running){
        yield return wait;
        if(!Connected)continue;
        using var req=UnityWebRequest.Get(apiBase+"/voice?ticket="+UnityWebRequest.EscapeURL(match.ticket)+"&after="+lastRemoteSeq);req.timeout=5;
        yield return req.SendWebRequest();
        if(req.result!=UnityWebRequest.Result.Success)continue;
        var list=JsonUtility.FromJson<OWVoiceList>(req.downloadHandler.text);
        if(list?.chunks==null)continue;
        foreach(var c in list.chunks){
          lastRemoteSeq=Mathf.Max(lastRemoteSeq,c.seq);
          try{Play(Convert.FromBase64String(c.data),c.sampleRate);}catch{}
        }
      }
    }

    float[] ReadCircular(AudioClip clip,int from,int to){
      int total=clip.samples;if(total<=0)return Array.Empty<float>();
      int count=to>=from?to-from:(total-from)+to;if(count<=0||count>total)return Array.Empty<float>();
      var result=new float[count];
      if(to>=from){clip.GetData(result,from);}
      else{
        int first=total-from;var a=new float[first];clip.GetData(a,from);Array.Copy(a,result,first);
        if(to>0){var b=new float[to];clip.GetData(b,0);Array.Copy(b,0,result,first,to);}
      }
      return result;
    }

    static byte[] FloatToPcm16(float[] samples){
      var bytes=new byte[samples.Length*2];
      for(int i=0;i<samples.Length;i++){short v=(short)Mathf.Clamp(samples[i]*32767f,short.MinValue,short.MaxValue);bytes[i*2]=(byte)(v&255);bytes[i*2+1]=(byte)((v>>8)&255);}
      return bytes;
    }

    void Play(byte[] pcm,int rate){
      int n=pcm.Length/2;if(n<=0)return;var f=new float[n];
      for(int i=0;i<n;i++){short v=(short)(pcm[i*2]|(pcm[i*2+1]<<8));f[i]=v/32768f;}
      var c=AudioClip.Create("OW_Voice",n,1,Mathf.Clamp(rate,8000,48000),false);c.SetData(f,0);playback.PlayOneShot(c,1f);Destroy(c,Mathf.Max(1f,n/(float)rate+1f));
    }

    static UnityWebRequest Post(string url,string json){
      var r=new UnityWebRequest(url,"POST");r.uploadHandler=new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));r.downloadHandler=new DownloadHandlerBuffer();r.SetRequestHeader("Content-Type","application/json");r.timeout=5;return r;
    }
  }
}
