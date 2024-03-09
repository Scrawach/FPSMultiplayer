using UnityEngine;

namespace Gameplay.Characters
{
    public class CharacterGroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _radius = 0.2f;
        [SerializeField] private float _coyoteTime = 0.15f;

        private float _elapsedTime;
        
        public bool IsGrounded { get; private set; }

        private void Update()
        {
            var isGrounded = Physics.CheckSphere(transform.position, _radius, _groundLayer);
            
            if (isGrounded)
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