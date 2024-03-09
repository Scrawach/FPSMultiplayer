using UnityEngine;

namespace Gameplay.Characters
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private CharacterGroundChecker _groundChecker;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpHeight = 1f;
        [SerializeField] private float _jumpDelay = 0.2f;

        private Vector3 _velocity;
        private float _previousJumpTime;

        public float Speed => _speed;

        private void Update()
        {
            _character.Move(_velocity * Time.deltaTime);
            _velocity = HandleGravity(_velocity);
        }
        
        public void MoveTo(Vector3 targetPosition)
        {
            var movementStep = MovementStep(targetPosition);
            _velocity = new Vector3(movementStep.x, _velocity.y, movementStep.z);
        }

        public void UpdateVelocityTo(Vector3 targetPosition)
        {
            var movementStep = MovementStep(targetPosition);
            _velocity = new Vector3(movementStep.x, movementStep.y, movementStep.z);
        }

        public void Jump()
        {
            if (!_groundChecker.IsGrounded)
                return;

            if (Time.time - _jumpDelay < _previousJumpTime)
                return;

            _previousJumpTime = Time.time;
            _velocity.y = _jumpHeight;
        }

        private Vector3 MovementStep(Vector3 targetPosition)
        {
            var direction = targetPosition - transform.position;
            return direction * _speed;
        }

        private Vector3 HandleGravity(Vector3 velocity)
        {
            var gravityStep = Physics.gravity.y * Time.deltaTime;
            velocity.y = Mathf.Clamp(velocity.y + gravityStep, Physics.gravity.y, _jumpHeight);
            return velocity;
        }
    }
}