using Network.Schemas;

namespace Network.Services.Listeners.Players
{
    public interface IPlayersChangeHandler
    {
        void Initialize();
        void PlayerAdded(string key, Player player);
        void PlayerRemoved(string key, Player player);
    }
}