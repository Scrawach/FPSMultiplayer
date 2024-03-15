using System;
using System.Collections.Generic;
using Network.Schemas;
using UI.Score;

namespace Network.Services.Listeners.Players
{
    public class UIPlayerInitializer : IPlayersChangeHandler
    {
        private readonly UIFactory _uiFactory;
        private readonly NetworkConnection _networkConnection;
        private readonly Dictionary<string, Action> _disposes;

        private ScoreTable _scoreTable;

        public UIPlayerInitializer(UIFactory uiFactory, NetworkConnection networkConnection)
        {
            _uiFactory = uiFactory;
            _networkConnection = networkConnection;
            _disposes = new Dictionary<string, Action>();
        }

        public void Initialize()
        {
            var uiRoot = _uiFactory.CreateUIRoot();
            _scoreTable = _uiFactory.CreateScoreTable(uiRoot);
        }
        
        public void PlayerAdded(string key, Player player)
        {
            _scoreTable.AddRow(key, _networkConnection.IsPlayer(key));
            _disposes[key] = player.OnScoreChange((current, previous) => OnPlayerScoreChanged(key, current, previous));
        }
        
        public void PlayerRemoved(string key, Player player)
        {
            _scoreTable.RemoveRow(key);
            _disposes[key].Invoke();
            _disposes[key] = null;
        }

        private void OnPlayerScoreChanged(string key, ScoreData current, ScoreData previous) => 
            _scoreTable.UpdateRow(key, current.kills, current.deaths);
    }
}