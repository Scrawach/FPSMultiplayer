using Network.Schemas;
using Network.Services;
using Reflex.Attributes;
using UnityEngine;

namespace Gameplay
{
    public class RemoteEnemy : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;

        private NetworkPositionPrediction _positionPrediction;
        
        [Inject]
        public void Construct(NetworkPositionPrediction positionPrediction) => 
            _positionPrediction = positionPrediction;

        public void OnMovementChange(Movement current, Movement previous)
        {
            _positionPrediction.Add(current);
            _movement.MoveTo(_positionPrediction.NextPosition());
        }
    }
}