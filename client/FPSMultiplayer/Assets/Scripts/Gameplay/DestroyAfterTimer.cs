using UnityEngine;

namespace Gameplay
{
    public class DestroyAfterTimer : MonoBehaviour
    {
        [SerializeField] private float _timeInSeconds;

        private void Start() => 
            Destroy(gameObject, _timeInSeconds);
    }
}