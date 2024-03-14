using Network.Schemas;
using UI;
using UI.Score;

namespace Network.Services.Listeners.Players
{
    public class UIPlayerInitializer : IPlayersChangeHandler
    {
        private readonly UIFactory _uiFactory;
        private readonly NetworkConnection _networkConnection;

        private ScoreTable _scoreTable;

        public UIPlayerInitializer(UIFactory uiFactory, NetworkConnection networkConnection)
        {
            _uiFactory = uiFactory;
            _networkConnection = networkConnection;
        }

        public void Initialize()
        {
            var uiRoot = _uiFactory.CreateUIRoot();
            _scoreTable = _uiFactory.CreateScoreTable(uiRoot);
        }
        
        public void PlayerAdded(string key, Player player) => 
            _scoreTable.AddRow(key, _networkConnection.IsPlayer(key));

        public void PlayerRemoved(string key, Player player) => 
            _scoreTable.RemoveRow(key);
    }
}