using Services;
using UnityEngine;

namespace UI.Score
{
    public class UiFactory
    {
        private const string ScoreTablePath = "UI/Score Table UI";
        private const string ScoreTableRowPath = "UI/Score Table Row";

        private readonly Assets _assets;

        public UiFactory(Assets assets) => 
            _assets = assets;

        public ScoreTable CreateScoreTable() => 
            _assets.Instantiate<ScoreTable>(ScoreTablePath);

        public ScoreTableRow CreateScoreRow(Transform parent) => 
            _assets.Instantiate<ScoreTableRow>(ScoreTableRowPath, parent);
    }
}