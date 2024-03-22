using System;
using Gameplay;
using Gameplay.Characters.Player;

namespace Network.Services.Data
{
    public class PlayerInfo : IDisposable
    {
        public readonly string Id;
        public readonly PlayerCharacter Player;
        public readonly Action[] DisposeActions;

        public PlayerInfo(string id, PlayerCharacter player, params Action[] disposeActions)
        {
            Id = id;
            Player = player;
            DisposeActions = disposeActions;
        }

        public void Dispose()
        {
            foreach (var disposeAction in DisposeActions) 
                disposeAction?.Invoke();
        }
    }
}