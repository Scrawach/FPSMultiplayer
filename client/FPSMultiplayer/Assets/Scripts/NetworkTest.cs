using Colyseus;
using Schemas;
using UnityEngine;

public class NetworkTest : MonoBehaviour
{
    [SerializeField] private ColyseusSettings _settings;

    private ColyseusRoom<State> _room;
    
    private async void Start()
    {
        const string roomName = "my_room";
        var client = new ColyseusClient(_settings.WebSocketEndpoint);
        _room = await client.JoinOrCreate<State>(roomName);
        _room.OnStateChange += OnStateChanged;
    }

    private void OnStateChanged(State state, bool isFirstState)
    {
        if (!isFirstState)
            return;
        
        Debug.Log($"{_room.SessionId}, position {state.players[_room.SessionId]}");
    }

    private void OnDestroy() => 
        _room.Leave();
}