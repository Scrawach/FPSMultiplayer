using Colyseus;
using UnityEngine;

public class NetworkTest : MonoBehaviour
{
    [SerializeField] private ColyseusSettings _settings;
    
    private async void Start()
    {
        const string roomName = "my_room";
        var client = new ColyseusClient(_settings.WebSocketEndpoint);
        var room = await client.JoinOrCreate<State>(roomName);
        await room.Leave();
    }
}