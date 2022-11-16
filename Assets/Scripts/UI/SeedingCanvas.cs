using Camera;
using DI;
using UnityEngine;

namespace UI
{
    public class SeedingCanvas : MonoBehaviour, IService, IInjectable
    {
        [SerializeField] private Vector3 canvasOffset;
    
        private Vector3 _cameraPosition;
        private Vector3 _cameraForwardVector;
        private GameObject _canvasGameObject;

        private void Awake()
        {
            _canvasGameObject = GetComponentInChildren<Canvas>().gameObject;
        }

        public void SetCanvas(Vector3 position)
        {
            _canvasGameObject.SetActive(true);
            transform.position = position + canvasOffset;
            transform.forward = _cameraForwardVector;
        }

        public void HideCanvas()
        {
            _canvasGameObject.SetActive(false);
        }


        public void Inject(IService service)
        {
            _cameraPosition = ((CameraController)service).GetPosition();
            _cameraForwardVector = ((CameraController)service).GetForwardVector();
        }
    }
}