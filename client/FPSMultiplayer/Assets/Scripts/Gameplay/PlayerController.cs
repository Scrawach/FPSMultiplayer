using Network.Services;
using Reflex.Attributes;
using Services;
using UnityEngine;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;

        private InputService _input;
        private NetworkManager _network;

        [Inject]
        public void Construct(InputService input, NetworkManager network)
        {
            _input = input;
            _network = network;
        }

        private void Update()
        {
            var moveDirection = _input.GetDirection();
            _movement.Move(moveDirection);
            _network.SendPosition(transform.position);
        }
    }
}