using Colyseus;
using Network.Schemas;
using UnityEngine;

namespace Network.Services.Listeners
{
    public class NetworkStateInitializer : INetworkRoomListener
    {
        private readonly NetworkPlayersInitializer _playersInitializer;
        private ColyseusRoom<State> _room;

        public NetworkStateInitializer(NetworkPlayersInitializer playersInitializer) => 
            _playersInitializer = playersInitializer;

        public void Listen(ColyseusRoom<State> room)
        {
            _room = room;
            _room.OnStateChange += OnStateChanged;
        }
        
        public void Dispose()
        {
            _room.OnStateChange -= OnStateChanged;
            _playersInitializer.Dispose();
        }

        private void OnStateChanged(State state, bool isFirstState)
        {
            if (isFirstState == false)
                return;
            
            _room.OnStateChange -= OnStateChanged;
            _playersInitializer.Initialize(state);
        }
    }
}