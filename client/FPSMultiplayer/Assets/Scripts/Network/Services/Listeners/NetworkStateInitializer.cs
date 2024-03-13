using Colyseus;
using Network.Schemas;
using UnityEngine;

namespace Network.Services.Listeners
{
    public class NetworkStateInitializer : INetworkRoomListener
    {
        private readonly NetworkPlayersInitializer _playersInitializer;
        private readonly NetworkUIInitializer _uiInitializer;
        private ColyseusRoom<State> _room;

        public NetworkStateInitializer(NetworkPlayersInitializer playersInitializer, NetworkUIInitializer uiInitializer)
        {
            _playersInitializer = playersInitializer;
            _uiInitializer = uiInitializer;
        }

        public void Listen(ColyseusRoom<State> room)
        {
            _room = room;
            _room.OnStateChange += OnStateChanged;
        }
        
        public void Dispose()
        {
            _room.OnStateChange -= OnStateChanged;
            _playersInitializer.Dispose();
            _uiInitializer.Dispose();
        }

        private void OnStateChanged(State state, bool isFirstState)
        {
            if (isFirstState == false)
                return;
            
            _room.OnStateChange -= OnStateChanged;
            _playersInitializer.Initialize(state);
            _uiInitializer.Initialize(state);
        }
    }
}