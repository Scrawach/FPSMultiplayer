using Extensions;
using Network.Schemas;
using UnityEngine;

namespace Gameplay
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float _lerpRate = 10f;
        
        private Vector3 _predicatedPosition;
        
        public void OnPositionChanged(Position current, Position previous) => 
            _predicatedPosition = PredictNextPosition(current, previous);

        private void Update() => 
            transform.position = Vector3.Lerp(transform.position, _predicatedPosition, _lerpRate * Time.deltaTime);
        
        private static Vector3 PredictNextPosition(Position current, Position previous)
        {
            if (previous is not null) 
                return current.ToVector3() + (current.ToVector3() - previous.ToVector3());
            return current.ToVector3();
        }
    }
}