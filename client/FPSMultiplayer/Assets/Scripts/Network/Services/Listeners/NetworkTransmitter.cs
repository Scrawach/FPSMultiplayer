using System.Collections.Generic;
using Colyseus;
using Network.Schemas;
using Network.Services.Data;
using UnityEngine;

namespace Network.Services.Listeners
{
    public class NetworkTransmitter : INetworkRoomHandler
    {
        private const string MovementEndPoint = "move";
        private const string ShootEndPoint = "shoot";
        private const string HealthChangeEndPoint = "healthChange";
        private const string TakeDamageEndPoint = "takeDamage";
        private const string EquipGunEndPoint = "equipGun";
        
        private ColyseusRoom<State> _room;

        public NetworkTransmitter()
        {
            Debug.Log($"Create {nameof(NetworkTransmitter)}");
        }
        
        public void Handle(ColyseusRoom<State> room) => 
            _room = room;

        public void Dispose() => 
            _room = null;
        
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

        public void SendHealthChange(int current, int total)
        {
            var message = new Dictionary<string, object>()
            {
                [nameof(current)] = current,
                [nameof(total)] = total
            };
            
            _room.Send(HealthChangeEndPoint, message);
        }

        public void SendTakeDamage(string targetId, string attackedId, int currentHealth)
        {
            var message = new Dictionary<string, object>()
            {
                [nameof(targetId)] = targetId,
                [nameof(attackedId)] = attackedId,
                [nameof(currentHealth)] = currentHealth
            };

            _room.Send(TakeDamageEndPoint, message);
        }

        public void SendEquipGun(int equippedGunId) => 
            _room.Send(EquipGunEndPoint, equippedGunId);
    }
}