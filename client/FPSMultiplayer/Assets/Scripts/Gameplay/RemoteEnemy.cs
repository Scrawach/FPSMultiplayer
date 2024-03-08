using Extensions;
using Network.Schemas;
using Network.Services.Logic;
using Reflex.Attributes;
using UnityEngine;

namespace Gameplay
{
    public class RemoteEnemy : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterRotation _rotation;

        private NetworkPositionPrediction _positionPrediction;
        
        [Inject]
        public void Construct(NetworkPositionPrediction positionPrediction) => 
            _positionPrediction = positionPrediction;

        public void OnMovementChange(Movement current, Movement previous)
        {
            _positionPrediction.Add(current);
            _movement.UpdateVelocityTo(_positionPrediction.NextPosition());
            _rotation.SetRotation(current.rotation.ToVector2());
        }

        public void Shoot(Vector3 position, Vector3 direction)
        {
            
        }
    }
}