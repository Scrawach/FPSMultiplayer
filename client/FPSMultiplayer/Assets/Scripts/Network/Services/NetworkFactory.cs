using Services;
using UnityEngine;

namespace Network.Services
{
    public class NetworkFactory
    {
        private const string PlayerPath = "Player";
    
        private readonly Injector _injector;

        public NetworkFactory(Injector injector) => 
            _injector = injector;

        public GameObject CreatePlayer(Vector3 position) => 
            CreateCharacter(PlayerPath, position);

        public GameObject CreateEnemy(Vector3 position) => 
            CreateCharacter(string.Empty, position);

        private GameObject CreateCharacter(string pathToPrefab, Vector3 position)
        {
            var prefab = LoadResource(pathToPrefab);
            var instance = Object.Instantiate(prefab, position, Quaternion.identity);
            return _injector.Inject(instance);
        }

        private GameObject LoadResource(string path) => 
            Resources.Load<GameObject>(path);
    }
}