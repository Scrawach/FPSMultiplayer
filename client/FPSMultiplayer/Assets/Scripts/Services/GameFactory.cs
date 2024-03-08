using Gameplay;
using UnityEngine;

namespace Services
{
    public class GameFactory
    {
        private const string PlayerPath = "Characters/Player";
        private const string EnemyPath = "Characters/Enemy";
    
        private readonly Injector _injector;
        private readonly CameraProvider _cameraProvider;

        public GameFactory(Injector injector, CameraProvider cameraProvider)
        {
            _injector = injector;
            _cameraProvider = cameraProvider;
        }

        public PlayerCharacter CreatePlayer(Vector3 position)
        {
            var player = CreateUnit<PlayerCharacter>(PlayerPath, position);
            _cameraProvider.LootOutOf(player.Eyes);
            _injector.Inject(player.gameObject);
            return player;
        }

        public RemoteEnemy CreateEnemy(Vector3 position)
        {
            var enemy = CreateUnit<RemoteEnemy>(EnemyPath, position);
            _injector.Inject(enemy.gameObject);
            return enemy;
        }

        public void Destroy(GameObject target) => 
            Object.Destroy(target);

        private static TUnit CreateUnit<TUnit>(string pathToPrefab, Vector3 position) where TUnit : Object
        {
            var prefab = Load<TUnit>(pathToPrefab);
            var instance = Object.Instantiate(prefab, position, Quaternion.identity);
            return instance;
        }

        private static TResource Load<TResource>(string path) where TResource : Object => 
            Resources.Load<TResource>(path);
    }
}