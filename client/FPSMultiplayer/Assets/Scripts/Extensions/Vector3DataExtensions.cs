using Network.Schemas;
using StaticData.Data;
using UnityEngine;

namespace Extensions
{
    public static class Vector3DataExtensions
    {
        public static Vector3 ToVector3(this Vector3Data data) =>
            new Vector3(data.x, data.y, data.z);

        public static Vector3Data ToData(this Vector3 vec3) =>
            new Vector3Data()
            {
                x = vec3.x,
                y = vec3.y,
                z = vec3.z
            };
    }
}