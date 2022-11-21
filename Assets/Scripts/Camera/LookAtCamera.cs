using System;
using DI;
using UnityEngine;

namespace Camera
{
    public class LookAtCamera : MonoBehaviour, IInjectable
    {
        private Transform _cameraTransform;

        public void Inject(IService service)
        {
            _cameraTransform = ((CameraController)service).transform;
        }

        private void LateUpdate()
        {
            transform.LookAt(_cameraTransform);
        }
    }
}