using System;
using System.Collections.Generic;
using Extensions;
using Network.Schemas;

namespace Network.Services.Listeners.Players
{
    public class NetworkPlayersListener : IDisposable
    {
        private readonly IEnumerable<IPlayersChangeHandler> _handles;
        private readonly List<Action> _disposes;

        public NetworkPlayersListener(IEnumerable<IPlayersChangeHandler> handles)
        {
            _handles = handles;
            _disposes = new List<Action>();
        }

        public void Initialize(State state)
        {
            foreach (var handle in _handles) 
                handle.Initialize();

            state.players.OnAdd(OnPlayerAdded).AddTo(_disposes);
            state.players.OnRemove(OnPlayerRemoved).AddTo(_disposes);
        }
        
        public void Dispose()
        {
            _disposes.ForEach(dispose => dispose?.Invoke());
            _disposes.Clear();
        }
        
        private void OnPlayerAdded(string key, Player player)
        {
            foreach (var handle in _handles) 
                handle.PlayerAdded(key, player);
        }
        
        private void OnPlayerRemoved(string key, Player player)
        {
            foreach (var handle in _handles) 
                handle.PlayerRemoved(key, player);
        }
    }
}