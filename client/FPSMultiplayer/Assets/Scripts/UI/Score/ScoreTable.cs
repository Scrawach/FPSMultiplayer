using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

namespace UI.Score
{
    public class ScoreTable : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        
        private readonly Dictionary<string, ScoreTableRow> _rows = new();

        private UIFactory _uiFactory;

        [Inject]
        public void Construct(UIFactory factory) => 
            _uiFactory = factory;


        public void AddRow(string key, bool isPlayer = false)
        {
            var row = _uiFactory.CreateScoreRow(key, _content);

            if (isPlayer)
                row.Highlight();
            
            _rows[key] = row;
        }

        public void RemoveRow(string key)
        {
            var instance = _rows[key];
            _uiFactory.Destroy(instance.gameObject);
            _rows.Remove(key);
        }
    }
}