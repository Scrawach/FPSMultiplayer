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
        private readonly IEnumerable<INetworkRoomHandler> _listeners;

        private ColyseusRoom<State> _room;

        public NetworkConnection(ColyseusClient client, IEnumerable<INetworkRoomHandler> listeners)
        {
            _client = client;
            _listeners = listeners;
        }
        
        public bool IsPlayer(string key) => 
            _room.SessionId == key;
        
        public async UniTask Connect(string sceneName, CharacterStats stats)
        {
            _room = await _client.JoinOrCreate<State>(GameRoomName, ConvertDataToDictionary(sceneName, stats));
            foreach (var listener in _listeners) 
                listener.Handle(_room);
        }

        public async UniTask Disconnect()
        {
            await _room.Leave();
            foreach (var listener in _listeners) 
                listener.Dispose();
        }

        private static Dictionary<string, object> ConvertDataToDictionary(string sceneName, CharacterStats stats) =>
            new Dictionary<string, object>()
            {
                ["SceneName"] = sceneName,
                ["CurrentHealth"] = 100,
                ["TotalHealth"] = 100,
                [nameof(CharacterStats)] = stats
            };
    }
}