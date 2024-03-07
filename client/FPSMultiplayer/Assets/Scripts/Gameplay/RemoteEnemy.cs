using Extensions;
using Network.Schemas;
using UnityEngine;

namespace Gameplay
{
    public class RemoteEnemy : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;

        private Vector3 _predicatedPosition;

        private void Start() => 
            _predicatedPosition = transform.position;

        private void Update() =>
            _movement.MoveTo(_predicatedPosition);

        public void OnPositionChanged(Vector3Data current, Vector3Data previous) => 
            _predicatedPosition = PredictNextPosition(current, previous);
        
        private static Vector3 PredictNextPosition(Vector3Data current, Vector3Data previous)
        {
            if (previous is null) 
                return current.ToVector3();
            
            var previousDirection = current.ToVector3() - previous.ToVector3();
            return current.ToVector3() + previousDirection;
        }
    }
}