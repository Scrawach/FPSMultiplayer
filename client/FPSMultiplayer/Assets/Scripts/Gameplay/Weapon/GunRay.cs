using Reflex.Attributes;
using Services;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class GunRay : MonoBehaviour
    {
        private const float MaxDistance = 25f;
        
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _center;
        [SerializeField] private Transform _point;
        [SerializeField] private float _pointSize = 0.025f;

        private CameraProvider _cameraProvider;
        
        [Inject]
        public void Construct(CameraProvider cameraProvider) => 
            _cameraProvider = cameraProvider;

        private void Update()
        {
            var ray = new Ray(_center.position, _center.forward);

            if (Physics.Raycast(ray, out var hit, MaxDistance, _layerMask, QueryTriggerInteraction.Ignore))
            {
                var cameraDistance = Vector3.Distance(_cameraProvider.MainCamera.transform.position, hit.point);
                UpdateMarkPosition(hit.distance, hit.point, cameraDistance);
            }
            else
            {
                UpdateMarkPosition(MaxDistance, _center.position + ray.direction * MaxDistance, MaxDistance);
            } 
        }

        private void UpdateMarkPosition(float distance, Vector3 markPoint, float cameraDistance)
        {
            _center.localScale = new Vector3(1, 1, distance / 2);
            _point.position = markPoint;
            _point.localScale = Vector3.one * cameraDistance * _pointSize;
        }
    }
}