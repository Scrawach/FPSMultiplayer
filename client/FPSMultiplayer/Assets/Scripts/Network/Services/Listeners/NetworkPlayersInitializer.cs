using System;
using System.Collections.Generic;
using Extensions;
using Network.Schemas;
using UI.Score;
using UnityEngine;

namespace Network.Services.Listeners
{
    public class NetworkPlayersInitializer
    {
        private readonly NetworkGameFactory _factory;
        private readonly UiFactory _uiFactory;
        private readonly List<Action> _disposes;

        private ScoreTable _scoreTable;

        public NetworkPlayersInitializer(NetworkGameFactory factory, UiFactory uiFactory)
        {
            _factory = factory;
            _uiFactory = uiFactory;
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

        private void OnPlayerAdded(string key, Player player)
        {
            _factory.CreateUnit(key, player);
            _scoreTable.AddRow(key);
        }

        private void OnPlayerRemoved(string key, Player value)
        {
            _factory.Destroy(key);
            _scoreTable.RemoveRow(key);
        }
    }
}