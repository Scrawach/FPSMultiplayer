using Network.Services;
using Reflex.Attributes;
using UnityEngine;

namespace Gameplay
{
    public class PlayerNetworkSync : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private CharacterRotation _rotation;
        
        private NetworkManager _network;

        [Inject]
        public void Construct(NetworkManager network) => 
            _network = network;

        private void Update()
        {
            var rotation = new Vector2(_rotation.HeadRotation, _rotation.transform.eulerAngles.y);
            _network.SendMovement(transform.position, _character.velocity, rotation);
        }
    }
}