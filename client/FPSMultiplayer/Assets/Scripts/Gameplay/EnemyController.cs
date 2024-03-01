using Extensions;
using Network.Schemas;
using UnityEngine;

namespace Gameplay
{
    public class EnemyController : MonoBehaviour
    {
        public void OnPositionChanged(Position current, Position previous) => 
            transform.position = current.ToVector3();
    }
}