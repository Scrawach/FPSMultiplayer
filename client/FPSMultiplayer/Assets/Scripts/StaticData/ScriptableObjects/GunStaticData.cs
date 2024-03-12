using StaticData.Data;
using UnityEngine;

namespace StaticData.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Guns Settings", menuName = "Guns Settings", order = 1)]
    public class GunStaticData : ScriptableObject
    {
        public GunSettings[] Settings;
    }
}