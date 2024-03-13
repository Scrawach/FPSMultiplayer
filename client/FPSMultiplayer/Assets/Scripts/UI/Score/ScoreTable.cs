using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

namespace UI.Score
{
    public class ScoreTable : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        
        private readonly Dictionary<string, ScoreTableRow> _rows = new();

        private UiFactory _uiFactory;

        [Inject]
        public void Construct(UiFactory factory) => 
            _uiFactory = factory;


        public void AddRow(string key) => 
            _rows[key] = _uiFactory.CreateScoreRow(key, _content);

        public void RemoveRow(string key)
        {
            var instance = _rows[key];
            _uiFactory.Destroy(instance);
            _rows.Remove(key);
        }
    }
}