using UnityEngine;

namespace Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private CharacterGroundChecker _groundChecker;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpHeight = 1f;
        [SerializeField] private float _jumpDelay = 0.2f;

        private Vector3 _targetPosition;
        private Vector3 _velocity;
        private float _previousJumpTime;

        public float Speed => _speed;

        private void Start() => 
            _targetPosition = transform.position;

        public void MoveTo(Vector3 targetPosition) =>
            _targetPosition = targetPosition;

        public void Jump()
        {
            if (!_groundChecker.IsGrounded)
                return;

            if (Time.time - _jumpDelay < _previousJumpTime)
                return;

            _previousJumpTime = Time.time;
            _velocity.y = _jumpHeight;
        }

        private void Update()
        {
            _velocity = HandleMovement(_velocity);
            _character.Move(_velocity * Time.deltaTime);
            _velocity = HandleGravity(_velocity);
        }

        private Vector3 HandleMovement(Vector3 velocity)
        {
            var direction = _targetPosition - transform.position;
            var movementStep = direction * _speed;
            return new Vector3(movementStep.x, velocity.y, movementStep.z);
        }
        
        private Vector3 HandleGravity(Vector3 velocity)
        {
            var gravityStep = Physics.gravity.y * Time.deltaTime;
            velocity.y = Mathf.Clamp(velocity.y + gravityStep, Physics.gravity.y, _jumpHeight);
            return velocity;
        }
    }
}