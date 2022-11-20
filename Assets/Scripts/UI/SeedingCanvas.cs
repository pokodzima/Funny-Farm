using Camera;
using DI;
using FarmTiles;
using UnityEngine;

namespace UI
{
    public class SeedingCanvas : MonoBehaviour, IService, IInjectable
    {
        [SerializeField] private Vector3 canvasOffset;
    
        private Vector3 _cameraPosition;
        private Vector3 _cameraForwardVector;
        private GameObject _canvasGameObject;
        public FarmTile CurrentTile { get; private set; }

        private void Awake()
        {
            _canvasGameObject = GetComponentInChildren<Canvas>().gameObject;
        }

        public void SetCanvas(FarmTile farmTile)
        {
            _canvasGameObject.SetActive(true);
            transform.position = farmTile.transform.position + canvasOffset;
            transform.forward = _cameraForwardVector;
            CurrentTile = farmTile;
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