using Colyseus;
using Cysharp.Threading.Tasks;
using Network.Schemas;
using Network.Services.Messages;

namespace Network.Services
{
    public class NetworkManager
    {
        private const string GameRoomName = "game_room";
        
        private readonly ColyseusClient _client;
        private readonly NetworkTransmitter _transmitter;
        private readonly INetworkRoomListener _listener;

        private ColyseusRoom<State> _room;

        public NetworkManager(ColyseusClient client, NetworkTransmitter transmitter, INetworkRoomListener listener)
        {
            _client = client;
            _transmitter = transmitter;
            _listener = listener;
        }

        public event ColyseusRoom<State>.RoomOnStateChangeEventHandler StateChanged;

        public async UniTask Connect()
        {
            _room = await _client.JoinOrCreate<State>(GameRoomName);
            _room.OnStateChange += OnStateChanged;
            _transmitter.Initialize(_room);
            _listener.Listen(_room);
        }

        public async UniTask Disconnect()
        {
            _room.OnStateChange -= OnStateChanged;
            await _room.Leave();
            _transmitter.Dispose();
            _room = null;
        }
        
        public bool IsPlayer(string key) => 
            _room.SessionId == key;

        private void OnStateChanged(State state, bool isFirstState) => 
            StateChanged?.Invoke(state, isFirstState);
        
    }
}