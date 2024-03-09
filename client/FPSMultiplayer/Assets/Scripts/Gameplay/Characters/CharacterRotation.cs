using UnityEngine;

namespace Gameplay.Characters
{
    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private float _minAngleX = -90f;
        [SerializeField] private float _maxAngleX = 90f;

        private float _currentRotateX;

        public float HeadRotation => _head.transform.localEulerAngles.x;

        public float Rotation => transform.localEulerAngles.y;
        
        public void SetRotation(Vector2 rotation)
        {
            _head.transform.localEulerAngles = new Vector3(rotation.x, 0, 0);
            transform.localEulerAngles = new Vector3(0, rotation.y, 0);
        }
        
        public void RotateHead(float angle)
        {
            _currentRotateX = Mathf.Clamp(_currentRotateX + angle, _minAngleX, _maxAngleX);
            _head.transform.localEulerAngles = new Vector3(_currentRotateX, 0, 0);
        }

        public void RotateCharacter(float angle) => 
            transform.Rotate(Vector3.up, angle);
    }
}