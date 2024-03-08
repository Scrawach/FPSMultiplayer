﻿using Extensions;
using Gameplay;
using Network.Schemas;
using Network.Services.Characters;
using Services;
using UnityEngine;

namespace Network.Services
{
    public class NetworkGameFactory
    {
        private readonly NetworkManager _network;
        private readonly GameFactory _factory;
        private readonly NetworkCharactersProvider _characters;

        public NetworkGameFactory(NetworkManager network, GameFactory factory, NetworkCharactersProvider characters)
        {
            _network = network;
            _factory = factory;
            _characters = characters;
        }
        
        public GameObject CreateUnit(string key, Player state) => 
            key == _network.Id 
                ? CreatePlayer(key, state) 
                : CreateEnemy(key, state);


        public void Destroy(string key)
        {
            var gameObject = Remove(key);
            _factory.Destroy(gameObject);
        }

        private GameObject Remove(string key)
        {
            if (key == _network.Id)
            {
                var playerInfo = _characters.GetPlayer();
                _characters.RemovePlayer();
                return playerInfo.Player.gameObject;
            }

            var enemyInfo = _characters.GetEnemy(key);
            _characters.RemoveEnemy(key);
            enemyInfo.Dispose();
            return enemyInfo.Enemy.gameObject;
        }

        private GameObject CreatePlayer(string key, Player state)
        {
            var instance = _factory.CreatePlayer(state.movement.position.ToVector3());
            _characters.AddPlayer(key, instance);
            return instance.gameObject;
        }

        private GameObject CreateEnemy(string key, Player state)
        {
            var enemy = _factory.CreateEnemy(state.movement.position.ToVector3());
            var enemyController = enemy.GetComponent<RemoteEnemy>();
            var dispose = state.OnMovementChange(enemyController.OnMovementChange);
            _characters.AddEnemy(key, enemy, dispose);
            return enemy.gameObject;
        }
    }
}