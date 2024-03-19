using UnityEngine;

namespace Gameplay.Weapon
{
    public class MuzzleFlashAnimator : MonoBehaviour
    {
        private static readonly int FireHash = Animator.StringToHash("Fire");

        [SerializeField] private Gun _gun;
        [SerializeField] private Animator _animator;

        private void OnEnable() => 
            _gun.Fired += OnFired;

        private void OnDisable() => 
            _gun.Fired -= OnFired;

        private void OnFired()
        {
            _animator.SetTrigger(FireHash);
        }
    }
}