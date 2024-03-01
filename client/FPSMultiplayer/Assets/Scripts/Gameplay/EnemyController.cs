using Extensions;
using Network.Schemas;
using UnityEngine;

namespace Gameplay
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;

        private bool _mustInitPosition;
        private Vector3 _initPosition;
        private Vector2 _predictedDirection;
        
        public void OnPositionChanged(Position current, Position previous)
        {
            _mustInitPosition = true;
            _initPosition = current.ToVector3();
            _predictedDirection = PredictMovementDirection(current, previous);
        }

        private static Vector2 PredictMovementDirection(Position current, Position previous)
        {
            if (previous is null)
                return Vector2.zero;

            return current.ToVector2() - previous.ToVector2();
        }
        
        private void Update()
        {
            if (_mustInitPosition)
            {
                transform.position = _initPosition;
                _mustInitPosition = false;
            }
            else
            {
                _movement.Move(_predictedDirection.normalized);
            }
        }
    }
}