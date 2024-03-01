using Network.Schemas;
using UnityEngine;

namespace Extensions
{
    public static class PositionExtensions
    {
        public static Vector3 ToVector3(this Position position) => 
            new Vector3(position.x, 0, position.y);

        public static Position AsPosition(this Vector3 position) => 
            new Position() {x = position.x, y = position.z};
    }
}