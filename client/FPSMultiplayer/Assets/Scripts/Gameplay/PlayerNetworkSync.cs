using Network.Services;
using Reflex.Attributes;
using UnityEngine;

namespace Gameplay
{
    public class PlayerNetworkSync : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        
        private NetworkManager _network;

        [Inject]
        public void Construct(NetworkManager network) => 
            _network = network;

        private void Update() => 
            _network.SendMovement(transform.position, _character.velocity);
    }
}