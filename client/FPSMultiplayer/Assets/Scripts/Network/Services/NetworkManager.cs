using System.Collections.Generic;
using Colyseus;
using Cysharp.Threading.Tasks;
using Network.Schemas;
using Network.Services.Listeners;

namespace Network.Services
{
    public class NetworkManager
    {
        private const string GameRoomName = "game_room";
        
        private readonly ColyseusClient _client;
        private readonly IEnumerable<INetworkRoomListener> _listeners;

        private ColyseusRoom<State> _room;

        public NetworkManager(ColyseusClient client, IEnumerable<INetworkRoomListener> listeners)
        {
            _client = client;
            _listeners = listeners;
        }

        public async UniTask Connect()
        {
            _room = await _client.JoinOrCreate<State>(GameRoomName);
            foreach (var listener in _listeners) 
                listener.Listen(_room);
        }

        public async UniTask Disconnect()
        {
            await _room.Leave();
            foreach (var listener in _listeners) 
                listener.Dispose();
        }

        public bool IsPlayer(string key) => 
            _room.SessionId == key;
    }
}