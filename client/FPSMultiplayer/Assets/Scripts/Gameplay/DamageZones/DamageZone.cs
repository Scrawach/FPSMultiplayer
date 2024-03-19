using UnityEngine;

namespace Gameplay.DamageZones
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private float DamageModifier = 1f;

        public void TakeDamage(string attackerId, int damage)
        {
            var totalDamage = (int) (damage * DamageModifier);
            _health.TakeDamage(attackerId, totalDamage);
        }
    }
}