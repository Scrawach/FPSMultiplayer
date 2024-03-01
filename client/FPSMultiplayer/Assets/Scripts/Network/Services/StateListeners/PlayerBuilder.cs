using Extensions;
using Schemas;

namespace Network.Services.StateListeners
{
    public class PlayerBuilder : INetworkStateListener
    {
        private readonly NetworkManager _network;
        private readonly NetworkFactory _factory;

        public PlayerBuilder(NetworkManager network, NetworkFactory factory)
        {
            _network = network;
            _factory = factory;
        }
    
        public void ChangeState(State state, bool isFirstState)
        {
            if (isFirstState == false)
                return;
        
            state.players.ForEach((key, player) =>
            {
                if (_network.Id == key)
                    _factory.CreatePlayer(player.position.ToVector3());
                else
                    _factory.CreateEnemy(player.position.ToVector3());
            });
        }
    }
}