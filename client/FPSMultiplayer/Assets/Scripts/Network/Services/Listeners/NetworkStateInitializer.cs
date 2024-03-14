using Colyseus;
using Network.Schemas;
using Network.Services.Listeners.Players;

namespace Network.Services.Listeners
{
    public class NetworkStateInitializer : INetworkRoomHandler
    {
        private readonly NetworkPlayersListener _playersListener;
        private ColyseusRoom<State> _room;

        public NetworkStateInitializer(NetworkPlayersListener playersListener)
        {
            _playersListener = playersListener;
        }

        public void Handle(ColyseusRoom<State> room)
        {
            _room = room;
            _room.OnStateChange += OnStateChanged;
        }
        
        public void Dispose()
        {
            _room.OnStateChange -= OnStateChanged;
            _playersListener.Dispose();
        }

        private void OnStateChanged(State state, bool isFirstState)
        {
            if (isFirstState == false)
                return;
            
            _room.OnStateChange -= OnStateChanged;
            _playersListener.Initialize(state);
        }
    }
}