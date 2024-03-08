using UnityEngine;

namespace Gameplay
{
    public class CharacterGroundChecker : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private float _coyoteTime = 0.15f;

        private float _elapsedTime;
        
        public bool IsGrounded { get; private set; }

        private void Update()
        {
            if (_character.isGrounded)
            {
                IsGrounded = true;
                _elapsedTime = 0;
            }
            else
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime > _coyoteTime)
                    IsGrounded = false;
            }
            
        }
    }
}