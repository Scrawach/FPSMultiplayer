using Reflex.Attributes;
using Services;
using UnityEngine;

namespace Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private InputService _input;

        [Inject]
        public void Construct(InputService input) => 
            _input = input;

        private void Update() => 
            Move(_input.GetDirection());

        private void Move(Vector2 direction)
        {
            var timeStep = _speed * Time.deltaTime;
            transform.position += timeStep * new Vector3(direction.x, 0, direction.y);
        }
    }
}