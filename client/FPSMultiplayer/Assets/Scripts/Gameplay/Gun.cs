using System;
using UnityEngine;

namespace Gameplay
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _shootDelay;

        private float _previousShootTime;

        public Transform ShootPoint => _shootPoint;
        
        public event Action Fired;

        public void Shoot()
        {
            if (IsCooldown()) 
                return;
            
            _previousShootTime = Time.time;
            var bullet = Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
            bullet.Construct(_shootPoint.forward);
            Fired?.Invoke();
        }

        private bool IsCooldown() => 
            Time.time < _previousShootTime + _shootDelay;
    }
}