using System;
using Reflex.Attributes;
using Services;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private int _id;
        [field: SerializeField] public Transform ShootPoint { get; private set; }
        [field: SerializeField] public float ShootCooldown { get; private set; }= 0.2f;
        [field: SerializeField] public int Damage { get; private set; } = 10;
        [field: SerializeField] public float BulletSpeed { get; private set; } = 20f;
        
        private BulletFactory _factory;

        public int Id => _id;
        
        public event Action Fired;

        [Inject]
        public void Construct(BulletFactory factory) => 
            _factory = factory;

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
        
        public void Shoot(string attackerId, int damage, Vector3 position, Vector3 velocity)
        {
            _factory.CreateBullet(attackerId, damage, position, velocity);
            Fired?.Invoke();
        }
    }
}