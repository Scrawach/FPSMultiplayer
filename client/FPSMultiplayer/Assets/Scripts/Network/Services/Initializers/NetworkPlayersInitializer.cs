using System;
using System.Collections.Generic;
using Extensions;
using Network.Schemas;

namespace Network.Services.Initializers
{
    public class NetworkPlayersInitializer : INetworkStateInitializer
    {
        private readonly NetworkGameFactory _factory;
        private readonly List<Action> _disposes;

        public NetworkPlayersInitializer(NetworkGameFactory factory)
        {
            _factory = factory;
            _disposes = new List<Action>();
        }

        public void Initialize(State state)
        {
            state.players.OnAdd(OnPlayerAdded).AddTo(_disposes);
            state.players.OnRemove(OnPlayerRemoved).AddTo(_disposes);
        }
        
        public void Dispose()
        {
            _disposes.ForEach(dispose => dispose?.Invoke());
            _disposes.Clear();
        }

        private void OnPlayerAdded(string key, Player player) => 
            _factory.CreateUnit(key, player);

        private void OnPlayerRemoved(string key, Player value) => 
            _factory.Destroy(key);
    }
}