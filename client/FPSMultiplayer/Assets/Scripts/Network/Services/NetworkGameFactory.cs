using Extensions;
using Gameplay;
using Gameplay.Characters;
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
        private readonly NetworkCharactersProvider _characters;

        public NetworkGameFactory(NetworkConnection network, GameFactory factory, NetworkCharactersProvider characters)
        {
            _network = network;
            _factory = factory;
            _characters = characters;
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
                var playerInfo = _characters.GetPlayer();
                _characters.RemovePlayer();
                return playerInfo.Player.gameObject;
            }

            var enemyInfo = _characters.GetEnemy(key);
            _characters.RemoveEnemy(key);
            enemyInfo.Dispose();
            return enemyInfo.EnemyCharacter.gameObject;
        }

        private GameObject CreatePlayer(string key, Player state)
        {
            var instance = _factory.CreatePlayer(state.movement.position.ToVector3());
            instance.UpdateStats(state.stats.ToStats());
            _characters.AddPlayer(key, instance);
            return instance.gameObject;
        }

        private GameObject CreateEnemy(string key, Player state)
        {
            var enemy = _factory.CreateEnemy(state.movement.position.ToVector3());
            var movementChangeDispose = state.OnMovementChange(enemy.OnMovementChange);
            var statsChangeDispose = state.OnStatsChange(enemy.OnStatsChange);
            _characters.AddEnemy(key, enemy, movementChangeDispose, statsChangeDispose);
            return enemy.gameObject;
        }
    }
}