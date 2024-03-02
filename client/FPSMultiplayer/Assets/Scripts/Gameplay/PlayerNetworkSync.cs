using Network.Services;
using Reflex.Attributes;
using UnityEngine;

namespace Gameplay
{
    public class PlayerNetworkSync : MonoBehaviour
    {
        private NetworkManager _network;

        [Inject]
        public void Construct(NetworkManager network) => 
            _network = network;

        private void Update() => 
            _network.SendPosition(transform.position);
    }
}