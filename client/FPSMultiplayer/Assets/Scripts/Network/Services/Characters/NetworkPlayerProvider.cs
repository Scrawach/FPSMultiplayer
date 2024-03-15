using System;
using Gameplay;
using Network.Services.Data;
using UnityEngine;

namespace Network.Services.Characters
{
    public class NetworkPlayerProvider
    {
        public PlayerInfo Player { get; private set; }

        public void Add(string key, PlayerCharacter player, params Action[] disposes) => 
            Player = new PlayerInfo(key, player, disposes);

        public bool Remove()
        {
            if (Player == null)
                return false;
            
            Player = default;
            return true;
        }

        public void Revive(Vector3 targetPosition) => 
            Player.Player.Revive(targetPosition);
    }
}