using UnityEngine;

namespace Gameplay.Characters.Enemy
{
    public class EnemyRotation : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private float _lerpRate = 0.25f;

        private float _targetHeadRotation;
        private float _targetBodyRotation;

        public void SetRotation(Vector2 rotation)
        {
            _targetHeadRotation = rotation.x;
            _targetBodyRotation = rotation.y;
        }

        private void Update()
        {
            _head.localEulerAngles = SmoothedHeadRotation();
            transform.localEulerAngles = SmoothedBodyRotation();
        }

        private Vector3 SmoothedHeadRotation()
        {
            var targetAngle = Mathf.LerpAngle(_head.localEulerAngles.x, _targetHeadRotation, _lerpRate);
            return new Vector3(targetAngle, 0, 0);
        }

        private Vector3 SmoothedBodyRotation()
        {
            var targetAngle = Mathf.LerpAngle(transform.localEulerAngles.y, _targetBodyRotation, _lerpRate);
            return new Vector3(0,targetAngle, 0);
        }
    }
}