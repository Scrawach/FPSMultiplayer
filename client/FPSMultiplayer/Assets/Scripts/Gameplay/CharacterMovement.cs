using UnityEngine;

namespace Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private float _speed = 5f;
        
        private Vector3 _targetPosition;

        private void Start() => 
            _targetPosition = transform.position;

        public void MoveTo(Vector3 targetPosition) =>
            _targetPosition = targetPosition;
        
        private void Update()
        {
            var direction = _targetPosition - transform.position;
            _character.SimpleMove(direction * _speed);
        }
    }
}