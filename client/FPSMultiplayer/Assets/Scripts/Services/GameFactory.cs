using Gameplay;
using Gameplay.Characters.Enemy;
using Gameplay.Characters.Player;
using UnityEngine;

namespace Services
{
    public class GameFactory
    {
        private const string PlayerPath = "Characters/Player";
        private const string EnemyPath = "Characters/Enemy";
    
        private readonly Assets _assets;
        private readonly CameraProvider _cameraProvider;

        public GameFactory(Assets assets, CameraProvider cameraProvider)
        {
            _assets = assets;
            _cameraProvider = cameraProvider;
        }

        public PlayerCharacter CreatePlayer(Vector3 position)
        {
            var player = CreateUnit<PlayerCharacter>(PlayerPath, position);
            _cameraProvider.LookOutOf(player.Eyes);
            return player;
        }

        public EnemyCharacter CreateEnemy(Vector3 position)
        {
            var enemy = CreateUnit<EnemyCharacter>(EnemyPath, position);
            return enemy;
        }

        public void Destroy(GameObject target) => 
            Object.Destroy(target);

        private TUnit CreateUnit<TUnit>(string pathToPrefab, Vector3 position) where TUnit : Object => 
            _assets.Instantiate<TUnit>(pathToPrefab, position);
    }
}