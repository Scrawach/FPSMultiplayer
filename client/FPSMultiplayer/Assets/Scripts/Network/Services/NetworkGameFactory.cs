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
        private readonly Dictionary<string, GameObject> _instances;

        public NetworkGameFactory(NetworkManager network, GameFactory factory)
        {
            _network = network;
            _factory = factory;
            _instances = new Dictionary<string, GameObject>();
        }
        
        public GameObject CreateUnit(string key, Player state)
        {
            _instances[key] = key == _network.Id
                ? CreatePlayer(state)
                : CreateEnemy(state);
            return _instances[key];
        }

        public void Destroy(string key)
        {
            var instance = _instances[key];
            _instances.Remove(key);
            Object.Destroy(instance);
        }

        private GameObject CreatePlayer(Player state) => 
            _factory.CreatePlayer(state.position.ToVector3());

        private GameObject CreateEnemy(Player state)
        {
            var enemy = _factory.CreateEnemy(state.position.ToVector3());
            var enemyController = enemy.GetComponent<EnemyMovement>();
            state.OnPositionChange(enemyController.OnPositionChanged);
            return enemy;
        }
    }
}