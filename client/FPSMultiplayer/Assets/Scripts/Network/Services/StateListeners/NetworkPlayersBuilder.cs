using Network.Schemas;

namespace Network.Services.StateListeners
{
    public class NetworkPlayersBuilder : INetworkStateListener
    {
        private readonly NetworkGameFactory _factory;

        public NetworkPlayersBuilder(NetworkGameFactory factory) => 
            _factory = factory;

        public void ChangeState(State state, bool isFirstState)
        {
            if (isFirstState == false)
                return;
            
            state.players.OnAdd(OnPlayerAdded);
            state.players.OnRemove(OnPlayerRemoved);
        }
        
        private void OnPlayerAdded(string key, Player player) => 
            _factory.CreateUnit(key, player);

        private void OnPlayerRemoved(string key, Player value) => 
            _factory.Destroy(key);
    }
}