using Gameplay;
using UnityEngine;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private SmoothFillingBar _fillingBar;

        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged() => 
            _fillingBar.SmoothFillTo(_health.Ratio);
    }
}