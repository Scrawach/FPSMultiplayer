using Reflex.Attributes;
using Services;
using UnityEngine;

namespace UI
{
    public class LookAtCamera : MonoBehaviour
    {
        private CameraProvider _camera;

        [Inject]
        public void Construct(CameraProvider cameraProvider) => 
            _camera = cameraProvider;

        private void Update() => 
            transform.LookAt(_camera.MainCamera.transform);
    }
}