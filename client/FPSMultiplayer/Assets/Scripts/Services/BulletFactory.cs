using Gameplay.Projectiles;
using UnityEngine;

namespace Services
{
    public class BulletFactory
    {
        private const string BulletPath = "Bullet";

        private readonly Assets _assets;

        public BulletFactory(Assets assets) => 
            _assets = assets;

        public Bullet CreateBullet(Vector3 position, Vector3 velocity)
        {
            var bullet = _assets.Instantiate<Bullet>(BulletPath, position);
            bullet.Construct(velocity);
            return bullet;
        }
    }
}