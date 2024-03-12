using System.Collections.Generic;
using System.Linq;
using Colyseus;
using Cysharp.Threading.Tasks;
using Network.Schemas;
using Network.Services.Listeners;
using StaticData.Data;

namespace Network.Services
{
    public class NetworkConnection
    {
        private const string GameRoomName = "game_room";
        
        private readonly ColyseusClient _client;
        private readonly IEnumerable<INetworkRoomListener> _listeners;

        private ColyseusRoom<State> _room;

        public NetworkConnection(ColyseusClient client, IEnumerable<INetworkRoomListener> listeners)
        {
            _client = client;
            _listeners = listeners;
        }
        
        public bool IsPlayer(string key) => 
            _room.SessionId == key;
        
        public async UniTask Connect(CharacterSettings settings)
        {
            _room = await _client.JoinOrCreate<State>(GameRoomName, Convert(settings));
            foreach (var listener in _listeners) 
                listener.Listen(_room);
        }

        public async UniTask Disconnect()
        {
            await _room.Leave();
            foreach (var listener in _listeners) 
                listener.Dispose();
        }

        private static Dictionary<string, object> Convert(CharacterSettings settings)
        {
            var fields = settings.GetType().GetFields();
            return fields.ToDictionary(field => field.Name, field => field.GetValue(settings));
        }
    }
}