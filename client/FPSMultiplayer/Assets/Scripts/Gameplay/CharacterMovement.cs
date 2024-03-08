using System;
using UnityEngine;

namespace Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpHeight = 1f;
        
        private Vector3 _targetPosition;
        private Vector3 _velocity;
        
        private bool _isJumping;
        private bool _isJumpPressed;

        private void Start() => 
            _targetPosition = transform.position;

        public void MoveTo(Vector3 targetPosition) =>
            _targetPosition = targetPosition;

        public void Jump()
        {
            if (!_isJumping)
                _isJumpPressed = true;
        }

        private void Update()
        {
            _velocity = HandleMovement(_velocity);
            _character.Move(_velocity * Time.deltaTime);

            _velocity = HandleGravity(_velocity);
            _velocity = HandleJump(_velocity);
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
            velocity.y = _character.isGrounded ? gravityStep : velocity.y + gravityStep;
            return velocity;
        }

        private Vector3 HandleJump(Vector3 velocity)
        {
            if (!_isJumping && _character.isGrounded && _isJumpPressed)
            {
                _isJumping = true;
                _isJumpPressed = false;
                velocity.y = _jumpHeight;
            }
            else if (!_isJumpPressed && _isJumping && _character.isGrounded)
            {
                _isJumping = false;
            }

            return velocity;
        }
    }
}