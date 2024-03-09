using UnityEngine;

namespace Gameplay
{
    public class BodyAnimator : MonoBehaviour
    {
        private static readonly int IsSitHash = Animator.StringToHash("IsSit");

        [SerializeField] private CharacterSitting _sitting;
        [SerializeField] private Animator _animator;

        private void Update() => 
            PlaySit(_sitting.IsSitting);

        public void PlaySit(bool state) => 
            _animator.SetBool(IsSitHash, state);
    }
}