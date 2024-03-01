using UnityEngine;

namespace Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
    
        public void Move(Vector2 direction)
        {
            var timeStep = _speed * Time.deltaTime;
            transform.position += timeStep * new Vector3(direction.x, 0, direction.y);
        }
    }
}