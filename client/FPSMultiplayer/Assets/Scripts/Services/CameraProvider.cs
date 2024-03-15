using UnityEngine;

namespace Services
{
    public class CameraProvider
    {
        public Camera MainCamera => Camera.main;
        
        public void LookOutOf(Transform point)
        {
            var cameraTransform = MainCamera.transform;
            cameraTransform.SetParent(point);
            cameraTransform.localPosition = Vector3.zero;
            cameraTransform.localRotation = Quaternion.identity;
        }
    }
}