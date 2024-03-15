using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Network.Services.Data
{
    [Serializable]
    public class NetworkShootInfo
    {
        public string Id;
        public Vector3 Position;
        public Vector3 Velocity;
    }
}