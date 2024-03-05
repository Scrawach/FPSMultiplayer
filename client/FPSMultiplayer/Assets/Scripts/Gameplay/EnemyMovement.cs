using Extensions;
using Network.Schemas;
using UnityEngine;

namespace Gameplay
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        
        private Vector3 _predicatedPosition;
        
        public void OnPositionChanged(Vector3Data current, Vector3Data previous) => 
            _predicatedPosition = PredictNextPosition(current, previous);

        private void Update() => 
            transform.position = Vector3.MoveTowards(transform.position, _predicatedPosition, _speed * Time.deltaTime);

        private static Vector3 PredictNextPosition(Vector3Data current, Vector3Data previous)
        {
            if (previous is null) 
                return current.ToVector3();
            
            var previousDirection = current.ToVector3() - previous.ToVector3();
            return current.ToVector3() + previousDirection;
        }
    }
}