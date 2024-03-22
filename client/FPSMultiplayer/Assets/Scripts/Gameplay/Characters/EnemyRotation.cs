using UnityEngine;

namespace Gameplay.Characters
{
    public class EnemyRotation : MonoBehaviour
    {
        [SerializeField] private Transform _head;

        private float _targetHeadRotation;
        private float _targetBodyRotation;

        public void SetRotation(Vector2 rotation)
        {
            _targetHeadRotation = rotation.x;
            _targetBodyRotation = rotation.y;
        }

        private void Update()
        {
            _head.localEulerAngles = new Vector3(_targetHeadRotation, 0, 0);
            transform.localEulerAngles = new Vector3(0, _targetBodyRotation, 0);
        }
    }
}