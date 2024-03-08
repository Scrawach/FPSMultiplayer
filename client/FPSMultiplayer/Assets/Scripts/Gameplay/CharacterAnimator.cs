using UnityEngine;

namespace Gameplay
{
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int GroundedHash = Animator.StringToHash("Grounded");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _character;
        [SerializeField] private CharacterMovement _movement;

        private void Update()
        {
            var localVelocity = _character.transform.InverseTransformVector(_character.velocity);
            var clampedSpeed = localVelocity.magnitude / _movement.Speed;
            var sign = Mathf.Sign(localVelocity.z);
            
            _animator.SetFloat(Speed, sign * clampedSpeed);
            _animator.SetBool(GroundedHash, !_movement.IsJumping);
        }
    }
}