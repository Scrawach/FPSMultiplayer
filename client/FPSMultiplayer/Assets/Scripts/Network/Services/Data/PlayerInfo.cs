using Gameplay;

namespace Network.Services.Data
{
    public struct PlayerInfo
    {
        public string Id;
        public PlayerCharacter Player;

        public PlayerInfo(string id, PlayerCharacter player)
        {
            Id = id;
            Player = player;
        }
    }
}