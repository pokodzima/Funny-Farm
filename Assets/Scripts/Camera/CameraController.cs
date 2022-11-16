using System;
using DI;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour, IService
    {
        private UnityEngine.Camera _camera;
        public void Awake()
        {
            _camera = GetComponent<UnityEngine.Camera>();
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Vector3 GetForwardVector()
        {
            return transform.forward;
        }

        public UnityEngine.Camera GetCamera()
        {
            return _camera;
        }
    }
}
