using System;
using Extensions;
using Network.Schemas;
using Network.Services;
using Reflex.Attributes;
using UnityEngine;

namespace Network.Components
{
    public class NetworkPositionSync : MonoBehaviour
    {
        private NetworkManager _network;

        [Inject]
        public void Construct(NetworkManager network) => 
            _network = network;

        public void OnPositionChanged(Position current, Position previous) => 
            transform.position = current.ToVector3();
    }
}