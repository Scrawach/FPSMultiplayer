using UnityEngine;

namespace Services
{
    public class GameFactory
    {
        private const string PlayerPath = "Player";
        private const string EnemyPath = "Enemy";
    
        private readonly Injector _injector;

        public GameFactory(Injector injector) => 
            _injector = injector;
        
        public GameObject CreatePlayer(Vector3 position) => 
            CreateUnit(PlayerPath, position);

        public GameObject CreateEnemy(Vector3 position) => 
            CreateUnit(EnemyPath, position);

        public void Destroy(GameObject target) => 
            Object.Destroy(target);

        private GameObject CreateUnit(string pathToPrefab, Vector3 position)
        {
            var prefab = Load<GameObject>(pathToPrefab);
            var instance = Object.Instantiate(prefab, position, Quaternion.identity);
            return _injector.Inject(instance);
        }

        private static TResource Load<TResource>(string path) where TResource : Object => 
            Resources.Load<TResource>(path);
    }
}