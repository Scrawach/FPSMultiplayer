using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Score
{
    public class ScoreTableRow : MonoBehaviour
    {
        [SerializeField] private Image _highlightBackground;
        [SerializeField] private TextMeshProUGUI _sessionId;
        [SerializeField] private TextMeshProUGUI _kills;
        [SerializeField] private TextMeshProUGUI _deaths;

        public void Construct(string sessionId) => 
            _sessionId.text = sessionId;

        public void UpdateStats(int kills, int deaths)
        {
            _kills.text = kills.ToString();
            _deaths.text = deaths.ToString();
        }

        public void Highlight() => 
            _highlightBackground.enabled = true;
    }
}