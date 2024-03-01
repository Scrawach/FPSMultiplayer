using Extensions;
using Gameplay;
using Network.Schemas;
using Services;
using UnityEngine;

namespace Network.Services
{
    public class NetworkFactory
    {
        private const string PlayerPath = "Player";
        private const string EnemyPath = "Enemy";
    
        private readonly Injector _injector;

        public NetworkFactory(Injector injector) => 
            _injector = injector;

        public GameObject CreatePlayer(Player state)
        {
            var position = state.position.ToVector3();
            var player = CreateCharacter(PlayerPath, position);
            return player;
        }

        public GameObject CreateEnemy(Player state)
        {
            var position = state.position.ToVector3();
            var enemy = CreateCharacter(EnemyPath, position);
            var enemyController = enemy.GetComponent<EnemyController>();
            state.OnPositionChange(enemyController.OnPositionChanged);
            return enemy;
        }
        
        private GameObject CreateCharacter(string pathToPrefab, Vector3 position)
        {
            var prefab = Load<GameObject>(pathToPrefab);
            var instance = Object.Instantiate(prefab, position, Quaternion.identity);
            return _injector.Inject(instance);
        }

        private static TResource Load<TResource>(string path) where TResource : Object => 
            Resources.Load<TResource>(path);
    }
}