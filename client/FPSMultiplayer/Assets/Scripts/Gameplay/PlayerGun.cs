using System;
using UnityEngine;

namespace Gameplay
{
    public class PlayerGun : MonoBehaviour
    {
        [SerializeField] private Gun _gun;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _shootDelay;
        [SerializeField] private float _speed;

        private float _previousShootTime;

        public Transform ShootPoint => _shootPoint;

        public float BulletSpeed => _speed;
        
        public event Action Fired
        {
            add => _gun.Fired += value;
            remove => _gun.Fired -= value;
        }
        
        public void Shoot()
        {
            if (IsCooldown()) 
                return;
            
            _previousShootTime = Time.time;
            _gun.Shoot(_shootPoint.position, _shootPoint.forward * _speed);
        }

        private bool IsCooldown() => 
            Time.time < _previousShootTime + _shootDelay;
        
    }
}