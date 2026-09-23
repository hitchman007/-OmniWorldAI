using System;
using UnityEngine;

namespace OnlyWar {
  [Serializable] public struct OnlyWarInputFrame {
    public int tick;
    public Vector2 move;
    public Vector2 look;
    public byte buttons;
  }

  [Serializable] public struct OnlyWarPlayerSnapshot {
    public int tick;
    public string playerId;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public byte stance;
    public ushort health;
    public ushort armor;
  }

  public interface IOnlyWarNetworkTransport {
    bool Connected { get; }
    int PingMs { get; }
    void Connect(string endpoint);
    void Disconnect();
    void SendInput(OnlyWarInputFrame frame);
    event Action<OnlyWarPlayerSnapshot> Snapshot;
  }

  public sealed class OnlyWarNetworkFacade : MonoBehaviour {
    public int simulationRate = 30;
    public int interpolationMs = 100;
    public bool serverAuthoritative = true;
    public string endpoint = "wss://replace-with-onlywar-match-server";
    public IOnlyWarNetworkTransport Transport { get; private set; }

    public void SetTransport(IOnlyWarNetworkTransport transport) => Transport = transport;
  }
}
