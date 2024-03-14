using Network.Services.Characters;
using Network.Services.Data;

namespace Network.Services.Messages
{
    public class ShootMessageHandler : MessageHandler<NetworkShootInfo>
    {
        private readonly NetworkCharactersProvider _characters;

        public ShootMessageHandler(NetworkCharactersProvider characters) 
            : base("shoot") =>
            _characters = characters;

        protected override void OnReceived(NetworkShootInfo message)
        {
            if (_characters.HasEnemy(message.Id) == false)
                return;
            
            var enemyInfo = _characters.GetEnemy(message.Id);
            enemyInfo.EnemyCharacter.Shoot(message.Position, message.Velocity);
        }
    }
}