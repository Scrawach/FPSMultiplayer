using Reflex.Attributes;
using Services;
using UnityEngine;

namespace Gameplay
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        
        private InputService _input;

        [Inject]
        public void Construct(InputService input) => 
            _input = input;

        private void Update()
        {
            var targetPosition = _input.Axis + transform.position;
            _movement.MoveTo(targetPosition);
        }
    }
}