using System;
using UnityEngine;

namespace StaticData.Data
{
    [Serializable]
    public class LevelData
    {
        public string SceneName;
        public Vector3[] SpawnPoints;
    }
}