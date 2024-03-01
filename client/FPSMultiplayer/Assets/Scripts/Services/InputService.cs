using UnityEngine;

namespace Services
{
    public class InputService
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        public Vector2 GetDirection() => 
            new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis)).normalized;
    }
}