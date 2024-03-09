using UnityEngine;

namespace Gameplay.Projectiles
{
    public class DestroyAfterTimer : MonoBehaviour
    {
        [SerializeField] private float _timeInSeconds;

        private void Start() => 
            Destroy(gameObject, _timeInSeconds);
    }
}