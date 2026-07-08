using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerVoiceChatSystem : MonoBehaviour
    {
        public static OmniMultiplayerVoiceChatSystem Instance;

        public bool VoiceEnabled { get; private set; }

        private float voiceActivityLevel;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        public void EnableVoice()
        {
            VoiceEnabled = true;

            Debug.Log("Voice chat enabled.");
        }


        public void DisableVoice()
        {
            VoiceEnabled = false;

            Debug.Log("Voice chat disabled.");
        }


        public void UpdateVoiceActivity(float level)
        {
            if (!VoiceEnabled)
                return;

            voiceActivityLevel = Mathf.Clamp01(level);
        }


        public float GetVoiceActivity()
        {
            return voiceActivityLevel;
        }


        public bool IsVoiceActive()
        {
            return VoiceEnabled;
        }
    }
}