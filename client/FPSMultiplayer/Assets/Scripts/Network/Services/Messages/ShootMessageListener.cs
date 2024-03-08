using Network.Services.Characters;
using Network.Services.Data;

namespace Network.Services.Messages
{
    public class ShootMessageListener : MessageListener<NetworkShootInfo>
    {
        private readonly NetworkCharactersProvider _characters;

        public ShootMessageListener(NetworkCharactersProvider characters) 
            : base("shoot") =>
            _characters = characters;

        protected override void OnReceived(NetworkShootInfo message)
        {
            if (_characters.HasEnemy(message.Id) == false)
                return;
            
            var enemyInfo = _characters.GetEnemy(message.Id);
            enemyInfo.Enemy.Shoot(message.Position, message.Velocity);
        }
    }
}