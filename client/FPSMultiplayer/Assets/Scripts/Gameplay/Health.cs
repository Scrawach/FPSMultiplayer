using System;
using UnityEngine;

namespace Gameplay
{
    public class Health : MonoBehaviour
    {
        public event Action Changed;
        
        public int Total { get; private set; }
        
        public int Current { get; private set; }

        public float Ratio => (float) Current / Total;
        
        public void Construct(int current, int total)
        {
            Total = total;
            Current = current;
        }
        
        public void TakeDamage(int damage)
        {
            Current = Mathf.Clamp(Current - damage, 0, Total);
            Changed?.Invoke();
        }

        public void Restore()
        {
            Current = Total;
            Changed?.Invoke();
        }
    }
}