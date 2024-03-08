using Extensions;
using Network.Schemas;
using UnityEngine;

namespace Gameplay
{
    public class RemoteEnemy : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;

        public void OnMovementChange(Movement current, Movement previous) => 
            _movement.MoveTo(PredictNextPosition(current.position, previous?.position));

        private static Vector3 PredictNextPosition(Vector3Data current, Vector3Data previous)
        {
            if (previous is null) 
                return current.ToVector3();
            
            var previousDirection = current.ToVector3() - previous.ToVector3();
            return current.ToVector3() + previousDirection;
        }
    }
}