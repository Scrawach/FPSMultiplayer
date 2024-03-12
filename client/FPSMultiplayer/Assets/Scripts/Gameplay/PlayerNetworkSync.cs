using Gameplay.Characters;
using Gameplay.Weapon;
using Network.Services.Listeners;
using Reflex.Attributes;
using Services;
using UnityEngine;

namespace Gameplay
{
    public class PlayerNetworkSync : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private CharacterRotation _rotation;
        [SerializeField] private CharacterSitting _sitting;
        [SerializeField] private Health _health;
        [SerializeField] private PlayerGun _gun;
        
        private NetworkTransmitter _transmitter;
        private InputService _input;

        [Inject]
        public void Construct(NetworkTransmitter network, InputService input)
        {
            _transmitter = network;
            _input = input;
        }

        private void OnEnable()
        {
            _gun.Fired += OnGunFired;
            _health.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _gun.Fired -= OnGunFired;
            _health.Changed -= OnHealthChanged;
        }
        
        private void OnGunFired()
        {
            var shootPoint = _gun.ShootPoint;
            _transmitter.SendShoot(shootPoint.position, shootPoint.forward * _gun.BulletSpeed);
        }
        
        private void OnHealthChanged() => 
            _transmitter.SendHealthChange(_health.Current, _health.Total);

        private void Update()
        {
            var rotation = new Vector2(_rotation.HeadRotation, _rotation.Rotation);
            var angles = _input.MouseAxis;
            var rotationAngles = new Vector2(-angles.x, angles.y);
            _transmitter.SendMovement(transform.position, _character.velocity, rotation, rotationAngles, _sitting.IsSitting);
        }
    }
}