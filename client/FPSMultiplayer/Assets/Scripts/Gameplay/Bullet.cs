using UnityEngine;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        
        public void Construct(Vector3 direction) => 
            _rigidbody.velocity = direction * _speed;
    }
}