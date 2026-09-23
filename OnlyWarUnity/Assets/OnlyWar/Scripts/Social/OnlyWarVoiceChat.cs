using UnityEngine;

namespace OnlyWar {
  public interface IOnlyWarVoiceTransport {
    bool Connected { get; }
    void JoinChannel(string channelId);
    void LeaveChannel();
    void SetMuted(bool muted);
    void SetPushToTalk(bool enabled);
  }

  public sealed class OnlyWarVoiceChat : MonoBehaviour {
    public bool pushToTalk;
    public bool muted;
    public IOnlyWarVoiceTransport Transport { get; private set; }
    public void SetTransport(IOnlyWarVoiceTransport transport)=>Transport=transport;
    public void Join(string channel)=>Transport?.JoinChannel(channel);
    public void Leave()=>Transport?.LeaveChannel();
    public void Mute(bool value){muted=value;Transport?.SetMuted(value);}
    public void PushToTalk(bool value){pushToTalk=value;Transport?.SetPushToTalk(value);}
  }
}
