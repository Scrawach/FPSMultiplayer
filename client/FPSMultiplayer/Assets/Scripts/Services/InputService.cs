using UnityEngine;

namespace Services
{
    public class InputService
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";

        private float _mouseSensitivity = 2f;

        public Vector3 MovementAxis => 
            new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis)).normalized;

        public Vector2 MouseAxis =>
            new Vector2(Input.GetAxis(MouseX), Input.GetAxis(MouseY)) * _mouseSensitivity;
    }
}