using System.Linq;
using Extensions;
using Network.Schemas;
using Structures;
using UnityEngine;

namespace Network.Services.Logic
{
    public class NetworkMovementPrediction
    {
        private readonly CircularBuffer<float> _receiveTimeIntervals;
        private float _lastReceiveTime;
        
        private Vector3 _position;
        private Vector3 _velocity;

        private Vector2 _rotation;
        private Vector2 _rotationAngles;

        public NetworkMovementPrediction() => 
            _receiveTimeIntervals = new CircularBuffer<float>(4);

        public void Add(Movement current)
        {
            SaveTimeInterval();
            _position = current.position.ToVector3();
            _velocity = current.velocity.ToVector3();
            _rotation = current.rotation.ToVector2();
            _rotationAngles = current.angles.ToVector2();
        }

        public Vector3 NextPosition() => 
            _position + _velocity * AverageTimeInterval();

        public Vector2 NextRotation() => 
            _rotation + _rotationAngles * AverageTimeInterval();

        private void SaveTimeInterval()
        {
            var timeInterval = Time.time - _lastReceiveTime;
            _receiveTimeIntervals.Add(timeInterval);
            _lastReceiveTime = Time.time;
        }

        private float AverageTimeInterval()
        {
            var sum = _receiveTimeIntervals.Sum();
            return sum / _receiveTimeIntervals.Size;
        }
    }
}