using UnityEngine;

namespace Gameplay.Characters
{
    public class CharacterRotation : MonoBehaviour
    {
        private const float RotationDelta = 180;
        
        [SerializeField] private Transform _head;
        [SerializeField] private float _minAngleX = -90f;
        [SerializeField] private float _maxAngleX = 90f;

        private float _targetHeadRotation;
        private float _targetBodyRotation;

        public float HeadRotation => _head.transform.localEulerAngles.x;

        public float Rotation => transform.localEulerAngles.y;
        
        public void SetRotation(Vector2 rotation)
        {
            _targetHeadRotation = rotation.x;
            _targetBodyRotation = rotation.y;
        }
        
        public void RotateHead(float angle) => 
            _targetHeadRotation = Mathf.Clamp(_targetHeadRotation + angle, _minAngleX, _maxAngleX);

        public void RotateCharacter(float angle) => 
            _targetBodyRotation += angle;

        private void Update()
        {
            ProcessHeadRotation();
            ProcessBodyRotation();
        }

        private void ProcessHeadRotation()
        {
            var headTransform = _head.transform;
            var targetAngle = Mathf.MoveTowardsAngle(headTransform.localEulerAngles.x, _targetHeadRotation, RotationDelta * Time.deltaTime);
            headTransform.localEulerAngles = new Vector3(targetAngle, 0, 0);
        }

        private void ProcessBodyRotation()
        {
            var targetAngle = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, _targetBodyRotation, RotationDelta * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, targetAngle, 0);
        }
    }
}