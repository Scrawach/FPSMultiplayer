using Network.Services.Characters;
using Network.Services.Data;

namespace Network.Services.Messages
{
    public class ShootMessageHandler : MessageHandler<NetworkShootInfo>
    {
        private readonly NetworkEnemyProvider _enemies;

        public ShootMessageHandler(NetworkEnemyProvider enemies) 
            : base("shoot") =>
            _enemies = enemies;

        protected override void OnReceived(NetworkShootInfo message)
        {
            if (_enemies.Has(message.Id) == false)
                return;
            
            var enemyInfo = _enemies[message.Id];
            enemyInfo.EnemyCharacter.Shoot(message.Position, message.Velocity);
        }
    }
}