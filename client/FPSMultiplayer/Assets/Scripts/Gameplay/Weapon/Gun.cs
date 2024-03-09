using System;
using Reflex.Attributes;
using Services;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class Gun : MonoBehaviour
    {
        private BulletFactory _factory;
        
        public event Action Fired;

        [Inject]
        public void Construct(BulletFactory factory) => 
            _factory = factory;

        public void Shoot(Vector3 position, Vector3 velocity)
        {
            _factory.CreateBullet(position, velocity);
            Fired?.Invoke();
        }
    }
}