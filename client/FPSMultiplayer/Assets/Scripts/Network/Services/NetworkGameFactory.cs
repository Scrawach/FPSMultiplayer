using Extensions;
using Gameplay;
using Network.Schemas;
using Services;
using UnityEngine;

namespace Network.Services
{
    public class NetworkGameFactory
    {
        private readonly GameFactory _factory;

        public NetworkGameFactory(GameFactory factory) => 
            _factory = factory;

        public GameObject CreatePlayer(Player state) => 
            _factory.CreatePlayer(state.position.ToVector3());

        public GameObject CreateEnemy(Player state)
        {
            var enemy = _factory.CreateEnemy(state.position.ToVector3());
            var enemyController = enemy.GetComponent<EnemyMovement>();
            state.OnPositionChange(enemyController.OnPositionChanged);
            return enemy;
        }
    }
}