using System;
using Network.Services;
using Reflex.Attributes;
using UnityEngine;

namespace Gameplay
{
    public class PlayerNetworkSync : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private CharacterRotation _rotation;
        [SerializeField] private Gun _gun;
        
        private NetworkTransmitter _transmitter;

        [Inject]
        public void Construct(NetworkTransmitter network) => 
            _transmitter = network;

        private void OnEnable() => 
            _gun.Fired += OnGunFired;

        private void OnDisable() => 
            _gun.Fired -= OnGunFired;

        private void OnGunFired()
        {
            var shootPoint = _gun.ShootPoint;
            _transmitter.SendShoot(shootPoint.position, shootPoint.forward);
        }

        private void Update()
        {
            var rotation = new Vector2(_rotation.HeadRotation, _rotation.Rotation);
            _transmitter.SendMovement(transform.position, _character.velocity, rotation);
        }
    }
}