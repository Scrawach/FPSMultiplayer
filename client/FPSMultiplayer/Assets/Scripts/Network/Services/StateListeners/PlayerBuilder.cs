using Extensions;
using Network.Components;
using Network.Schemas;
using UnityEngine;

namespace Network.Services.StateListeners
{
    public class PlayerBuilder : INetworkStateListener
    {
        private readonly NetworkManager _network;
        private readonly NetworkFactory _factory;

        public PlayerBuilder(NetworkManager network, NetworkFactory factory)
        {
            _network = network;
            _factory = factory;
        }
    
        public void ChangeState(State state, bool isFirstState)
        {
            if (isFirstState == false)
                return;
            
            state.players.OnAdd(OnPlayerAdded);
        }
        
        private void OnPlayerAdded(string key, Player player) => 
            CreatePlayer(key, player);

        private GameObject CreatePlayer(string key, Player player)
        {
            var position = player.position.ToVector3();
            return _network.Id == key 
                ? _factory.CreatePlayer(position) 
                : CreateEnemy(key, player);
        }

        private GameObject CreateEnemy(string key, Player player)
        {
            var enemy = _factory.CreateEnemy(player.position.ToVector3());
            player.OnPositionChange(enemy.GetComponent<NetworkPositionSync>().OnPositionChanged);
            return enemy;
        }
    }
}