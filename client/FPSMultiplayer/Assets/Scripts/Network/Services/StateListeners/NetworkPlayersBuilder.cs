using System.Collections.Generic;
using Network.Schemas;
using UnityEngine;

namespace Network.Services.StateListeners
{
    public class NetworkPlayersBuilder : INetworkStateListener
    {
        private readonly NetworkManager _network;
        private readonly NetworkFactory _factory;

        private readonly Dictionary<string, GameObject> _instances;

        public NetworkPlayersBuilder(NetworkManager network, NetworkFactory factory)
        {
            _network = network;
            _factory = factory;
            _instances = new Dictionary<string, GameObject>();
        }
    
        public void ChangeState(State state, bool isFirstState)
        {
            if (isFirstState == false)
                return;
            
            state.players.OnAdd(OnPlayerAdded);
            state.players.OnRemove(OnPlayerRemoved);
        }
        
        private void OnPlayerAdded(string key, Player player) => 
            _instances[key] = CreatePlayer(key, player);

        private void OnPlayerRemoved(string key, Player value)
        {
            var instance = _instances[key];
            _instances.Remove(key);
            Object.Destroy(instance);
        }
        
        private GameObject CreatePlayer(string key, Player player) =>
            _network.Id == key 
                ? _factory.CreatePlayer(player) 
                : _factory.CreateEnemy(player);
    }
}