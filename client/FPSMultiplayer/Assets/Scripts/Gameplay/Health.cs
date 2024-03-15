using System;
using UnityEngine;

namespace Gameplay
{
    public class Health : MonoBehaviour
    {
        public event Action Changed;

        public event Action<string> DamageTaken;
        
        [field: SerializeField] public int Total { get; private set; }
        
        [field: SerializeField] public int Current { get; private set; }

        public float Ratio => (float) Current / Total;
        
        public void Construct(int current, int total)
        {
            Total = total;
            Current = current;
        }
        
        public void TakeDamage(string attackerId, int damage)
        {
            Current = Mathf.Clamp(Current - damage, 0, Total);
            Changed?.Invoke();
            DamageTaken?.Invoke(attackerId);
        }

        public void Restore()
        {
            Current = Total;
            Changed?.Invoke();
        }
    }
}