using System;
using Gameplay;
using Network.Services.Data;

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
    }
}