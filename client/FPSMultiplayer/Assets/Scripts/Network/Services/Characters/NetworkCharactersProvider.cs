using System;
using System.Collections.Generic;
using Gameplay;
using Network.Services.Data;

namespace Network.Services.Characters
{
    public class NetworkCharactersProvider
    {
        private readonly Dictionary<string, EnemyInfo> _enemies;
        private PlayerInfo _player;

        public NetworkCharactersProvider() => 
            _enemies = new Dictionary<string, EnemyInfo>();

        public void AddPlayer(string key, PlayerCharacter character) => 
            _player = new PlayerInfo(key, character);

        public void AddEnemy(string key, RemoteEnemy enemy, Action dispose = null) => 
            _enemies[key] = new EnemyInfo(key, enemy, dispose);

        public bool HasEnemy(string key) =>
            _enemies.ContainsKey(key);
        
        public EnemyInfo GetEnemy(string key) => 
            _enemies[key];

        public bool RemoveEnemy(string key) => 
            _enemies.Remove(key);

        public PlayerInfo GetPlayer() => 
            _player;

        public void RemovePlayer() => 
            _player = default;
    }
}