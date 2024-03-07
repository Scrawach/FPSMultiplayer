using System.Collections.Generic;
using Extensions;
using Gameplay;
using Network.Schemas;
using Services;
using UnityEngine;

namespace Network.Services
{
    public class NetworkGameFactory
    {
        private readonly NetworkManager _network;
        private readonly GameFactory _factory;
        private readonly Dictionary<string, NetworkGameObject> _gameObjects;

        public NetworkGameFactory(NetworkManager network, GameFactory factory)
        {
            _network = network;
            _factory = factory;
            _gameObjects = new Dictionary<string, NetworkGameObject>();
        }
        
        public GameObject CreateUnit(string key, Player state)
        {
            var networkGameObject = CreateNetworkUnit(key, state);
            return networkGameObject.Instance;
        }
        
        public void Destroy(string key)
        {
            var networkGameObject = _gameObjects[key];
            _gameObjects.Remove(key);
            networkGameObject.Dispose?.Invoke();
            _factory.Destroy(networkGameObject.Instance);
        }

        private NetworkGameObject CreateNetworkUnit(string key, Player state) =>
            _gameObjects[key] = key == _network.Id
                ? CreatePlayer(state)
                : CreateEnemy(state);

        private NetworkGameObject CreatePlayer(Player state)
        {
            var instance = _factory.CreatePlayer(state.position.ToVector3());
            return new NetworkGameObject(state, instance);
        }

        private NetworkGameObject CreateEnemy(Player state)
        {
            var enemy = _factory.CreateEnemy(state.position.ToVector3());
            var enemyController = enemy.GetComponent<EnemyMovement>();
            var dispose = state.OnPositionChange(enemyController.OnPositionChanged);
            return new NetworkGameObject(state, enemy, dispose);
        }
    }
}