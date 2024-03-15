using Gameplay.Characters;
using Gameplay.Weapon;
using Network.Schemas;
using Network.Services.Listeners;
using Network.Services.Logic;
using Reflex.Attributes;
using UnityEngine;

namespace Gameplay
{
    public class EnemyCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterRotation _rotation;
        [SerializeField] private CharacterSitting _sitting;
        [SerializeField] private UniqueId _uniqueId;
        [SerializeField] private Health _health;
        [SerializeField] private GunsEquipment _guns;
        
        private NetworkMovementPrediction _movementPrediction;
        private NetworkTransmitter _transmitter;
        
        [Inject]
        public void Construct(NetworkMovementPrediction movementPrediction, NetworkTransmitter transmitter)
        {
            _movementPrediction = movementPrediction;
            _transmitter = transmitter;
        }

        private void OnEnable() => 
            _health.DamageTaken += OnDamageTaken;

        private void OnDisable() => 
            _health.DamageTaken -= OnDamageTaken;

        private void OnDamageTaken(string attacker) => 
            _transmitter.SendTakeDamage(_uniqueId.Value, attacker, _health.Current);

        public void OnMovementChange(Movement current, Movement previous)
        {
            _movementPrediction.Add(current);
            _movement.UpdateVelocityTo(_movementPrediction.NextPosition());
            _rotation.SetRotation(_movementPrediction.NextRotation());
            _sitting.UpdateState(current.isSitting);
        }

        public void OnEquippedGunChange(byte current, byte previous) => 
            _guns.Equip(current);
        
        public void Shoot(Vector3 position, Vector3 velocity) => 
            _guns.Current.Shoot(string.Empty, 0, position, velocity);

        public void OnHealthChange(HealthData current, HealthData previous)
        {
            if (previous == null)
                return;
            
            if (current.current > previous.current) 
                _health.Construct(current.current, current.total);
        }
    }
}