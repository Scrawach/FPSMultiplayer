using System.Threading.Tasks;
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
        
        room.OnStateChange += (state, isFirstState) =>
        {
            if (!isFirstState)
                return;
            
            Debug.Log($"{room.SessionId}, position {state.players[room.SessionId]}");
        };

        await Task.Delay(1000);
        await room.Leave();
    }
}