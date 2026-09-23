using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarAudioDirector : MonoBehaviour {
    public AudioMixerSnapshotProxy combat, calm, lowHealth;
    public AudioSource music;
    public AudioSource ui;
    public AudioClip hitMarker, headshot, killConfirm, objective, warning;

    public void SetCombat(bool active){(active?combat:calm)?.Transition(.35f);}
    public void SetLowHealth(bool active){if(active)lowHealth?.Transition(.15f);else combat?.Transition(.25f);}
    public void Hit(bool head){if(ui)ui.PlayOneShot(head&&headshot?headshot:hitMarker);}
    public void Kill(){if(ui&&killConfirm)ui.PlayOneShot(killConfirm);}
    public void Objective(){if(ui&&objective)ui.PlayOneShot(objective);}
    public void Warning(){if(ui&&warning)ui.PlayOneShot(warning);}
  }

  [System.Serializable] public sealed class AudioMixerSnapshotProxy {
    public UnityEngine.Audio.AudioMixerSnapshot snapshot;
    public void Transition(float seconds){if(snapshot)snapshot.TransitionTo(seconds);}
  }
}
