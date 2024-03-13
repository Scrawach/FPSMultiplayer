using System.Collections.Generic;
using System.Linq;
using Environment;
using StaticData.Data;
using StaticData.ScriptableObjects;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string CollectButtonText = "Collect";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button(CollectButtonText)) 
                UpdateLevelData();

            EditorUtility.SetDirty(target);
        }

        private void UpdateLevelData()
        {
            var staticData = (LevelStaticData) target;
            
            staticData.Data = new LevelData()
            {
                SceneName = SceneManager.GetActiveScene().name,
                SpawnPoints = SpawnPointsOnCurrentScene().ToArray()
            };
        }

        private IEnumerable<Vector3> SpawnPointsOnCurrentScene() => 
            FindObjectsByType<SpawnPointMarker>(FindObjectsSortMode.None)
                .Select(marker => marker.transform.position);
    }
}