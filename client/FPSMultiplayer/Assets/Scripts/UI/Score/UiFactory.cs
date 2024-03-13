using Services;
using UnityEngine;

namespace UI.Score
{
    public class UiFactory
    {
        private const string UIRootPath = "UI/UI Root";
        private const string ScoreTablePath = "UI/Score Table UI";
        private const string ScoreTableRowPath = "UI/Score Table Row";
        
        private readonly Assets _assets;

        private GameObject _root;

        public UiFactory(Assets assets) => 
            _assets = assets;

        public GameObject CreateUIRoot() => 
            _root = _assets.Instantiate<GameObject>(UIRootPath);

        public ScoreTable CreateScoreTable() => 
            _assets.Instantiate<ScoreTable>(ScoreTablePath, _root.transform);

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