using System;
using DI;
using UnityEngine;
using UnityEngine.Events;

namespace Camera
{
    public class CameraController : MonoBehaviour, IService
    {
        [SerializeField] private float cameraFocusOrthographicSize = 3;
        private UnityEngine.Camera _camera;
        private Vector3 _initialPosition;
        private float _initialCamSize;
        public UnityEvent<bool> FocusChanged;

        private void Awake()
        {
            _initialPosition = GetPosition();
            _initialCamSize = _camera.orthographicSize;
        }

        private void Start()
        {
            FocusChanged?.Invoke(false);
        }

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

        public void FocusCamera(Vector3 position)
        {
            transform.position = position;
            _camera.orthographicSize = cameraFocusOrthographicSize;
            FocusChanged?.Invoke(true);
        }

        public void UnFocusCamera()
        {
            transform.position = _initialPosition;
            _camera.orthographicSize = _initialCamSize;
            FocusChanged?.Invoke(false);
        }
    }
}
