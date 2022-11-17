using System;
using DI;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour, IService
    {
        private UnityEngine.Camera _camera;

        public UnityEngine.Camera Camera
        {
            get
            {
                if (_camera == null)
                {
                    _camera = GetComponent<UnityEngine.Camera>();
                }
                return _camera;
            }
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Vector3 GetForwardVector()
        {
            return transform.forward;
        }
    }
}
