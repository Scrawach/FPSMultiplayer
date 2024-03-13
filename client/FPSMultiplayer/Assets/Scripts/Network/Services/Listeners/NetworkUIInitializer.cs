using System;
using System.Collections.Generic;
using Extensions;
using Network.Schemas;
using UI.Score;

namespace Network.Services.Listeners
{
    public class NetworkUIInitializer : IDisposable
    {
        private readonly UiFactory _uiFactory;
        private readonly NetworkConnection _networkConnection;
        private readonly List<Action> _disposes;

        private ScoreTable _scoreTable;

        public NetworkUIInitializer(UiFactory uiFactory, NetworkConnection networkConnection)
        {
            _uiFactory = uiFactory;
            _networkConnection = networkConnection;
            _disposes = new List<Action>();
        }

        public void Initialize(State state)
        {
            _uiFactory.CreateUIRoot();
            _scoreTable = _uiFactory.CreateScoreTable();
            
            state.players.OnAdd(OnPlayerAdded).AddTo(_disposes);
            state.players.OnRemove(OnPlayerRemoved).AddTo(_disposes);
        }
        
        public void Dispose()
        {
            _disposes.ForEach(dispose => dispose?.Invoke());
            _disposes.Clear();
        }

        private void OnPlayerAdded(string key, Player player) => 
            _scoreTable.AddRow(key, _networkConnection.IsPlayer(key));

        private void OnPlayerRemoved(string key, Player value) => 
            _scoreTable.RemoveRow(key);
    }
}