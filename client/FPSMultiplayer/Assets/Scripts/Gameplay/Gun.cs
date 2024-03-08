using System;
using UnityEngine;

namespace Gameplay
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;

        public event Action Fired;

        public void Shoot(Vector3 position, Vector3 velocity)
        {
            var bullet = Instantiate(_bullet, position, Quaternion.identity);
            bullet.Construct(velocity);
            Fired?.Invoke();
        }
    }
}