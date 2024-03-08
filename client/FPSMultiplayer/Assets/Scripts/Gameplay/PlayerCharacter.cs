using Reflex.Attributes;
using Services;
using UnityEngine;

namespace Gameplay
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterRotation _rotation;

        [field: SerializeField] public Transform Eyes { get; private set; } 
        
        private InputService _input;

        [Inject]
        public void Construct(InputService input) => 
            _input = input;

        private void Update()
        {
            MoveTo(_input.MovementAxis);
            RotateTo(_input.MouseAxis);
        }

        private void MoveTo(Vector3 direction)
        {
            var nextPosition = transform.position + direction;
            _movement.MoveTo(nextPosition);
        }

        private void RotateTo(Vector2 mouseAxis)
        {
            _rotation.RotateX(-mouseAxis.y);
            _rotation.RotateY(mouseAxis.x);
        }
    }
}