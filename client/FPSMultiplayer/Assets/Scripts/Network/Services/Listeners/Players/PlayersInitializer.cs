using Network.Schemas;

namespace Network.Services.Listeners.Players
{
    public class PlayersInitializer : IPlayersChangeHandler
    {
        private readonly NetworkGameFactory _factory;

        public PlayersInitializer(NetworkGameFactory factory) => 
            _factory = factory;

        public void Initialize() { }

        public void PlayerAdded(string key, Player player) => 
            _factory.CreateUnit(key, player);

        public void PlayerRemoved(string key, Player player) => 
            _factory.Destroy(key);
    }
}