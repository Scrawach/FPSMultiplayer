using Network.Schemas;
using UnityEngine;

namespace Extensions
{
    public static class Vector2DataExtensions
    {
        public static Vector2 ToVector2(this Vector2Data data) => 
            new Vector2(data.x, data.y);
    }
}