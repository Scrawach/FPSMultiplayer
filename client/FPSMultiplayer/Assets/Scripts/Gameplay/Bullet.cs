using UnityEngine;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public void Construct(Vector3 velocity) => 
            _rigidbody.velocity = velocity;

        private void OnCollisionEnter(Collision collision) => 
            Destroy(gameObject);
    }
}