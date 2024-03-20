using UnityEngine;

namespace Gameplay.DamageZones
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private float _damageModifier = 1f;

        public void TakeDamage(string attackerId, int damage)
        {
            var totalDamage = (int) (damage * _damageModifier);
            _health.TakeDamage(attackerId, totalDamage);
        }
    }
}