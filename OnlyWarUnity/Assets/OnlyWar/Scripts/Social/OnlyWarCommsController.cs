using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarCommsController : MonoBehaviour {
    public OnlyWarTextChatClient textChat;
    public OnlyWarVoiceChat voice;
    public OnlyWarVoiceHttpTransport voiceTransport;
    public OnlyWarHttpMatchClient match;

    void Awake(){
      if(!match)match=FindFirstObjectByType<OnlyWarHttpMatchClient>();
      if(!textChat)textChat=GetComponent<OnlyWarTextChatClient>()??gameObject.AddComponent<OnlyWarTextChatClient>();
      textChat.match=match;
      if(!voiceTransport)voiceTransport=GetComponent<OnlyWarVoiceHttpTransport>()??gameObject.AddComponent<OnlyWarVoiceHttpTransport>();
      voiceTransport.match=match;
      if(!voice)voice=GetComponent<OnlyWarVoiceChat>()??gameObject.AddComponent<OnlyWarVoiceChat>();
      voice.SetTransport(voiceTransport);
      if(match!=null)match.OnTicket+=OnTicket;
    }

    void OnTicket(OWTicketResponse ticket){
      if(ticket!=null&&ticket.status=="matched"){
        voice.Join(ticket.roomId);
      }
    }

    public void SendTeamText(string value)=>textChat?.Send(value);
    public void PushToTalkDown()=>voiceTransport?.SetTransmit(true);
    public void PushToTalkUp()=>voiceTransport?.SetTransmit(false);
  }
}
