using Gameplay.Characters;
using Gameplay.Weapon;
using Reflex.Attributes;
using Services;
using StaticData.Data;
using UnityEngine;

namespace Gameplay
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterRotation _rotation;
        [SerializeField] private CharacterSitting _sitting;
        [SerializeField] private Health _health;
        [SerializeField] private PlayerGun _gun;

        [field: SerializeField] public Transform Eyes { get; private set; } 
        
        private InputService _input;

        [Inject]
        public void Construct(InputService input) => 
            _input = input;

        public void UpdateStats(CharacterStats stats)
        {
            _movement.Construct(stats.Speed, stats.JumpHeight);
            _health.Construct(stats.CurrentHealth, stats.TotalHealth);
        }
        
        public void Revive(Vector3 targetPosition)
        {
            _health.Restore();
            _movement.MoveTo(Vector3.zero);
            _movement.enabled = false;
            transform.position = targetPosition;
            _movement.enabled = true; 
        }
        
        private void Update()
        {
            MoveTo(_input.MovementAxis);
            RotateTo(_input.MouseAxis);
            
            if (_input.IsJumpPressed())
                _movement.Jump();
            
            if (_input.IsShootPressed())
                _gun.TryShoot();
            
            if (_input.IsChangeWeaponPressed(out var gunId))
                _gun.Equip(gunId);

            _sitting.UpdateState(_input.IsSit());
        }

        private void MoveTo(Vector3 direction)
        {
            var nextPosition = transform.position + TransformInputRelativeToBody(direction);
            _movement.MoveTo(nextPosition);
        }

        private Vector3 TransformInputRelativeToBody(Vector3 input)
        {
            var playerTransform = transform;
            return playerTransform.forward * input.z + playerTransform.right * input.x;
        }

        private void RotateTo(Vector2 mouseAxis)
        {
            _rotation.RotateHead(-mouseAxis.y);
            _rotation.RotateCharacter(mouseAxis.x);
        }
    }
}