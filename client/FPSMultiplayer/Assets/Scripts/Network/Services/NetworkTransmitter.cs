using System;
using System.Collections.Generic;
using Colyseus;
using Network.Schemas;
using Network.Services.Data;
using UnityEngine;

namespace Network.Services
{
    public class NetworkTransmitter : IDisposable
    {
        private const string MovementEndPoint = "move";
        private const string ShootEndPoint = "shoot";
        
        private ColyseusRoom<State> _room;

        public void Initialize(ColyseusRoom<State> room) => 
            _room = room;

        public void SendMovement(Vector3 position, Vector3 velocity, Vector2 rotation, Vector2 angles,  bool isSitting)
        {
            var message = new Dictionary<string, object>()
            {
                [nameof(position)] = position,
                [nameof(velocity)] = velocity,
                [nameof(rotation)] = rotation,
                [nameof(angles)] = angles,
                [nameof(isSitting)] = isSitting
            };
            
            _room.Send(MovementEndPoint, message);
        }

        public void SendShoot(Vector3 position, Vector3 velocity)
        {
            var shootInfo = new NetworkShootInfo()
            {
                Id = _room.SessionId,
                Position = position,
                Velocity = velocity
            };
            
            _room.Send(ShootEndPoint, shootInfo);
        }

        public void Dispose() => 
            _room = null;
    }
}