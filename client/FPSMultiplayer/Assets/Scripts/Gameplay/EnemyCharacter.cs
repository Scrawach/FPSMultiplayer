using System;
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
        [SerializeField] private Gun _gun;
        
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

        private void OnDamageTaken(string attackedId)
        {
            _transmitter.SendTakeDamage(_uniqueId.Value, attackedId, _health.Current);
        }

        public void OnMovementChange(Movement current, Movement previous)
        {
            _movementPrediction.Add(current);
            _movement.UpdateVelocityTo(_movementPrediction.NextPosition());
            _rotation.SetRotation(_movementPrediction.NextRotation());
            _sitting.UpdateState(current.isSitting);
        }

        public void OnStatsChange(CharacterStatsData current, CharacterStatsData previous) => 
            _health.Construct(current.currentHealth, current.totalHealth);

        public void Shoot(Vector3 position, Vector3 velocity) => 
            _gun.Shoot("enemy", 0, position, velocity);
    }
}