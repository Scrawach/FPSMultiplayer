using UnityEngine;

namespace Gameplay
{
    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField] private Transform _head;

        public void RotateX(float angle)
        {
            _head.Rotate(angle, 0, 0);
        }

        public void RotateY(float angle)
        {
            transform.Rotate(Vector3.up, angle);
        }
    }
}