using System;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class PlayerGun : MonoBehaviour
    {
        [SerializeField] private UniqueId _uniqueId;
        [SerializeField] private GunsEquipment _equipment;

        private float _previousShootTime;

        public Transform ShootPoint => _equipment.Current.ShootPoint;

        public float BulletSpeed => _equipment.Current.BulletSpeed;

        public event Action<int> Equipped
        {
            add => _equipment.Equipped += value;
            remove => _equipment.Equipped -= value;
        }

        public event Action Fired
        {
            add => _equipment.Current.Fired += value;
            remove => _equipment.Current.Fired -= value;
        }

        public void Equip(int gunId) => 
            _equipment.Equip(gunId);

        public void Shoot()
        {
            if (IsCooldown()) 
                return;
            
            _previousShootTime = Time.time;
            _equipment.Current.Shoot(_uniqueId.Value, _equipment.Current.Damage, ShootPoint.position, ShootPoint.forward * _equipment.Current.BulletSpeed);
        }

        private bool IsCooldown() => 
            Time.time < _previousShootTime + _equipment.Current.ShootCooldown;
        
    }
}