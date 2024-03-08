using UnityEngine;

namespace Gameplay
{
    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private float _minAngleX = -90f;
        [SerializeField] private float _maxAngleX = 90f;

        private float _currentRotateX;
        
        public void RotateX(float angle)
        {
            _currentRotateX = Mathf.Clamp(_currentRotateX + angle, _minAngleX, _maxAngleX);
            _head.transform.localEulerAngles = new Vector3(_currentRotateX, 0, 0);
        }

        public void RotateY(float angle)
        {
            transform.Rotate(Vector3.up, angle);
        }
    }
}