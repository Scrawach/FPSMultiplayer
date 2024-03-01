using Extensions;
using Schemas;
using UnityEngine;

namespace Network
{
    public class NetworkPositionSync : MonoBehaviour
    {
        private NetworkTest _network;

        public void Construct(NetworkTest network) => 
            _network = network;

        public void OnPositionChanged(Position current, Position previous) => 
            transform.position = current.ToVector3();

        private void Update() => 
            _network.SendPosition(transform.position);
    }
}