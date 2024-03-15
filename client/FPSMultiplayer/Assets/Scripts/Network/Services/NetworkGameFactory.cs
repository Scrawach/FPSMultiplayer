using Extensions;
using Gameplay;
using Network.Schemas;
using Network.Services.Characters;
using Services;
using UnityEngine;

namespace Network.Services
{
    public class NetworkGameFactory
    {
        private readonly NetworkConnection _network;
        private readonly GameFactory _factory;
        private readonly NetworkPlayerProvider _player;
        private readonly NetworkEnemyProvider _enemies;

        public NetworkGameFactory(NetworkConnection network, GameFactory factory, NetworkPlayerProvider player,
            NetworkEnemyProvider enemies)
        {
            _network = network;
            _factory = factory;
            _player = player;
            _enemies = enemies;
        }
        
        public GameObject CreateUnit(string key, Player state) =>
            _network.IsPlayer(key)
                ? CreatePlayer(key, state)
                : CreateEnemy(key, state);

        public void Destroy(string key)
        {
            var gameObject = Remove(key);
            _factory.Destroy(gameObject);
        }

        private GameObject Remove(string key)
        {
            if (_network.IsPlayer(key))
            {
                var playerInfo = _player.Player;
                _player.Remove();
                playerInfo.Dispose();
                return playerInfo.Player.gameObject;
            }

            var enemyInfo = _enemies[key];
            _enemies.Remove(key);
            enemyInfo.Dispose();
            return enemyInfo.EnemyCharacter.gameObject;
        }

        private GameObject CreatePlayer(string key, Player state)
        {
            var instance = _factory.CreatePlayer(state.movement.position.ToVector3());
            instance.GetComponent<UniqueId>().Construct(key);
            var networkSync = instance.GetComponent<PlayerNetworkSync>();
            var healthChangeDispose = state.OnHealthChange(networkSync.OnHealthChanged);
            instance.UpdateStats(state.stats.ToStats());
            _player.Add(key, instance, healthChangeDispose);
            return instance.gameObject;
        }

        private GameObject CreateEnemy(string key, Player state)
        {
            var enemy = _factory.CreateEnemy(state.movement.position.ToVector3());
            enemy.GetComponent<UniqueId>().Construct(key);
            var movementChangeDispose = state.OnMovementChange(enemy.OnMovementChange);
            var equippedGunChangeDispose = state.OnEquippedGunChange(enemy.OnEquippedGunChange);
            _enemies.Add(key, enemy, movementChangeDispose, equippedGunChangeDispose);
            return enemy.gameObject;
        }
    }
}