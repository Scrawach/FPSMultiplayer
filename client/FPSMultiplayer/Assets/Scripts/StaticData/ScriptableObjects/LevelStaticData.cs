using StaticData.Data;
using UnityEngine;

namespace StaticData.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level Settings", menuName = "Level Settings", order = 2)]
    public class LevelStaticData : ScriptableObject
    {
        public LevelData Data;
    }
}