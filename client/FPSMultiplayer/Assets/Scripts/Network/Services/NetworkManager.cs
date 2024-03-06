using System.Threading.Tasks;
using Colyseus;
using Extensions;
using Network.Schemas;
using UnityEngine;

namespace Network.Services
{
    public class NetworkManager
    {
        private const string SetPositionEndPoint = "setPosition";
        private const string GameRoomName = "game_room";
        
        private readonly ColyseusClient _client;

        private ColyseusRoom<State> _room;

        public NetworkManager(ColyseusClient client) => 
            _client = client;

        public event ColyseusRoom<State>.RoomOnStateChangeEventHandler StateChanged;

        public string Id => _room.SessionId;

        public async Task Connect()
        {
            _room = await _client.JoinOrCreate<State>(GameRoomName);
            _room.OnStateChange += OnStateChanged;
        }
    
        public async Task Disconnect()
        {
            _room.OnStateChange -= OnStateChanged;
            await _room.Leave();
        }

        public void SendPosition(Vector3 position) => 
            _room.Send(SetPositionEndPoint, position.ToData());

        private void OnStateChanged(State state, bool isFirstState) => 
            StateChanged?.Invoke(state, isFirstState);
    }
}