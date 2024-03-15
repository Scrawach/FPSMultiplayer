using Extensions;
using Network.Schemas;
using Network.Services.Characters;

namespace Network.Services.Messages
{
    public class RespawnMessageHandler : MessageHandler<Vector3Data>
    {
        private readonly NetworkPlayerProvider _playerProvider;

        public RespawnMessageHandler(NetworkPlayerProvider playerProvider) 
            : base("respawn") =>
            _playerProvider = playerProvider;

        protected override void OnReceived(Vector3Data message) => 
            _playerProvider.Revive(message.ToVector3());
    }
}