using UnityEngine;

namespace Gameplay
{
    public class GunAnimator : MonoBehaviour
    {
        private static readonly int ShootHash = Animator.StringToHash("Shoot");

        [SerializeField] private Gun _gun;
        [SerializeField] private Animator _animator;

        private void OnEnable() => 
            _gun.Fired += OnGunFired;

        private void OnDisable() => 
            _gun.Fired -= OnGunFired;

        private void OnGunFired() => 
            _animator.SetTrigger(ShootHash);
    }
}