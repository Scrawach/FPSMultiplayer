using System;
using System.Collections.Generic;
using Gameplay;
using Gameplay.Characters.Enemy;
using Network.Services.Data;

namespace Network.Services.Characters
{
    public class NetworkEnemyProvider
    {
        private readonly Dictionary<string, EnemyInfo> _enemies;

        public NetworkEnemyProvider() => 
            _enemies = new Dictionary<string, EnemyInfo>();

        public EnemyInfo this[string key] => _enemies[key];
        
        public bool Has(string key) => 
            _enemies.ContainsKey(key);

        public void Add(string key, EnemyCharacter enemy, params Action[] disposes) => 
            _enemies[key] = new EnemyInfo(key, enemy, disposes);

        public bool Remove(string key) => 
            _enemies.Remove(key);
    }
}