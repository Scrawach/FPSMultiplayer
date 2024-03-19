using Gameplay.DamageZones;
using UnityEngine;

namespace Gameplay.Projectiles
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private string _attackedId;
        private int _damage;
        
        public void Construct(Vector3 velocity, string attackerId, int damage)
        {
            _rigidbody.velocity = velocity;
            _attackedId = attackerId;
            _damage = damage;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out DamageZone damageZone)) 
                damageZone.TakeDamage(_attackedId, _damage);

            Destroy(gameObject);
        }
    }
}