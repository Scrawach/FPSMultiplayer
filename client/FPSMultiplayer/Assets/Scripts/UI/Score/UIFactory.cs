using Services;
using UnityEngine;

namespace UI.Score
{
    public class UIFactory
    {
        private const string UIRootPath = "UI/UI Root";
        private const string ScoreTablePath = "UI/Score Table UI";
        private const string ScoreTableRowPath = "UI/Score Table Row";
        
        private readonly Assets _assets;

        public UIFactory(Assets assets) => 
            _assets = assets;

        public UIRoot CreateUIRoot() => 
            _assets.Instantiate<UIRoot>(UIRootPath);

        public ScoreTable CreateScoreTable(UIRoot root)
        {
            var table = _assets.Instantiate<ScoreTable>(ScoreTablePath, root.transform);
            root.ScoreTable = table;
            return table;
        }

        public ScoreTableRow CreateScoreRow(string sessionId, Transform parent)
        {
            var row = _assets.Instantiate<ScoreTableRow>(ScoreTableRowPath, parent);
            row.Construct(sessionId);
            row.UpdateStats(0, 0);
            return row;
        }

        public void Destroy(ScoreTableRow instance) => 
            Object.Destroy(instance);
    }
}