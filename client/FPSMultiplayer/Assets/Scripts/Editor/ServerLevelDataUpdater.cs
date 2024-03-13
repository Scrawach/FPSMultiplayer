using System.Collections.Generic;
using System.IO;
using System.Linq;
using Environment;
using StaticData.Data;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public static class ServerLevelDataUpdater
    {
        private const string PathToServerStaticData = "../../server/FPSMultiplayerServer/src/staticData";

        [InitializeOnLoadMethod]
        public static void Start() => 
            EditorSceneManager.sceneSaved += OnSceneSaved;

        private static void OnSceneSaved(Scene scene) => 
            UpdateSceneDataOnServer(scene);

        private static void UpdateSceneDataOnServer(Scene scene)
        {
            var jsonData = GetLevelDataAsJson(scene);
            ExportToServerStaticData(scene.name, jsonData);
            
            Debug.Log($"[Scene saved] Update {scene.name} scene data on server!");
        }

        private static void ExportToServerStaticData(string filename, string content)
        {
            var correctPathToServer = PathToServerStaticData.Replace('/', Path.DirectorySeparatorChar);
            using var writer = new StreamWriter(Path.Combine(correctPathToServer, $"{filename}.json"), false);
            writer.WriteLine(content);
        }

        private static string GetLevelDataAsJson(Scene scene) =>
            JsonUtility.ToJson(new LevelData
            {
                SceneName = scene.name, 
                SpawnPoints = FindAllSpawnPoints(scene).ToArray()
            });

        private static IEnumerable<Vector3> FindAllSpawnPoints(Scene scene) => 
            FindAllObjectOfType<SpawnPointMarker>(scene)
                .Select(marker => marker.transform.position);

        private static IEnumerable<TComponent> FindAllObjectOfType<TComponent>(Scene scene) => 
            GetAllRootGameObjects(scene)
                .SelectMany(gameObject => gameObject.GetComponentsInChildren<TComponent>());

        private static IEnumerable<GameObject> GetAllRootGameObjects(Scene scene) => 
            scene.GetRootGameObjects();
    }
}