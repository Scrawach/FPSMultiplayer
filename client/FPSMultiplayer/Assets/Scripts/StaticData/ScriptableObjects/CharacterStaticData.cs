using StaticData.Data;
using UnityEngine;

namespace StaticData.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Character Settings", menuName = "Character Settings", order = 0)]
    public class CharacterStaticData : ScriptableObject
    {
        public CharacterStats stats;
    }
}