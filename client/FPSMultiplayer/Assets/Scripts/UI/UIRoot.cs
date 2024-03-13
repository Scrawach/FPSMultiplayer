using Reflex.Attributes;
using Services;
using UI.Score;
using UnityEngine;

namespace UI
{
    public class UIRoot : MonoBehaviour
    {
        public ScoreTable ScoreTable;

        private InputService _input;
        
        [Inject]
        public void Construct(InputService input) => 
            _input = input;

        private void Update()
        {
            if (_input.IsScoreBoardShown())
                ScoreTable.gameObject.SetActive(true);
            else
                ScoreTable.gameObject.SetActive(false);
        }
    }
}