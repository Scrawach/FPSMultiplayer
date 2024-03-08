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
        
        private NetworkManager _network;

        [Inject]
        public void Construct(NetworkManager network) => 
            _network = network;

        private void OnEnable() => 
            _gun.Fired += OnGunFired;

        private void OnDisable() => 
            _gun.Fired -= OnGunFired;

        private void OnGunFired()
        {
            var shootPoint = _gun.ShootPoint;
            _network.SendShoot(shootPoint.position, shootPoint.forward);
        }

        private void Update()
        {
            var rotation = new Vector2(_rotation.HeadRotation, _rotation.Rotation);
            _network.SendMovement(transform.position, _character.velocity, rotation);
        }
    }
}