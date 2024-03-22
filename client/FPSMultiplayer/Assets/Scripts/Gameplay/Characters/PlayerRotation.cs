using UnityEngine;

namespace Gameplay.Characters
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private float _minAngleX = -90f;
        [SerializeField] private float _maxAngleX = 90f;

        private float _currentHeadRotation;
        private float _currentBodyRotation;
        
        public float HeadRotation => _head.transform.localEulerAngles.x;

        public float Rotation => transform.localEulerAngles.y;
        
        public void RotateHead(float angle)
        {
            _currentHeadRotation = Mathf.Clamp(_currentHeadRotation + angle, _minAngleX, _maxAngleX);
            _head.localEulerAngles = new Vector3(_currentHeadRotation, 0, 0);
        }

        public void RotateCharacter(float angle)
        {
            _currentBodyRotation += angle;
            transform.localEulerAngles = new Vector3(0, _currentBodyRotation, 0);
        }
    }
}