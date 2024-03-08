using UnityEngine;

namespace Services
{
    public class CameraProvider
    {
        public void LootOutOf(Transform point)
        {
            var cameraTransform = Camera.main.transform;
            cameraTransform.SetParent(point);
            cameraTransform.localPosition = Vector3.zero;
            cameraTransform.localRotation = Quaternion.identity;
        }
    }
}