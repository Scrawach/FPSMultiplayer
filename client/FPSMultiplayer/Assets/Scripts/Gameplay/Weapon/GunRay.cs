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

            if (!Physics.Raycast(ray, out var hit, MaxDistance, _layerMask, QueryTriggerInteraction.Ignore))
            {
                _center.localScale = new Vector3(1, 1, MaxDistance);
                return;
            }
            
            _center.localScale = new Vector3(1, 1, hit.distance);
            _point.position = hit.point;
            var distance = Vector3.Distance(_cameraProvider.MainCamera.transform.position, hit.point);
            _point.localScale = Vector3.one * distance * _pointSize;
        }
    }
}