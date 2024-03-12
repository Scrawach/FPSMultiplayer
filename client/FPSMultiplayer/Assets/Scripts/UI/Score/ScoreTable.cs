using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

namespace UI.Score
{
    public class ScoreTable : MonoBehaviour
    {
        private readonly Dictionary<string, ScoreTableRow> _rows = new();

        private UiFactory _uiFactory;

        [Inject]
        public void Construct(UiFactory factory) => 
            _uiFactory = factory;
        
        
    }
}