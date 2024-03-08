using System.Collections.Generic;
using Colyseus;
using Cysharp.Threading.Tasks;
using Network.Schemas;
using UnityEngine;

namespace Network.Services
{
    public class NetworkManager
    {
        private const string MovementEndPoint = "move";
        private const string ShootEndPoint = "shoot";
        private const string GameRoomName = "game_room";
        
        
        private readonly ColyseusClient _client;

        private ColyseusRoom<State> _room;

        public NetworkManager(ColyseusClient client) => 
            _client = client;

        public event ColyseusRoom<State>.RoomOnStateChangeEventHandler StateChanged;

        public string Id => _room.SessionId;

        public async UniTask Connect()
        {
            _room = await _client.JoinOrCreate<State>(GameRoomName);
            _room.OnStateChange += OnStateChanged;
        }
    
        public async UniTask Disconnect()
        {
            _room.OnStateChange -= OnStateChanged;
            await _room.Leave();
        }

        private void OnStateChanged(State state, bool isFirstState) => 
            StateChanged?.Invoke(state, isFirstState);

        public void SendMovement(Vector3 position, Vector3 velocity, Vector2 rotation)
        {
            var message = new Dictionary<string, Vector3>()
            {
                [nameof(position)] = position,
                [nameof(velocity)] = velocity,
                [nameof(rotation)] = rotation
            };
            
            _room.Send(MovementEndPoint, message);
        }

        public void SendShoot(Vector3 position, Vector3 direction)
        {
            var message = new Dictionary<string, object>()
            {
                [nameof(Id)] = Id,
                [nameof(position)] = position,
                [nameof(direction)] = direction
            };

            _room.Send(ShootEndPoint, message);
        }
    }
}