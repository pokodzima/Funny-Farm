using Camera;
using DI;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Clicker
{
    public class Clicker : MonoBehaviour, IInjectable
    {
        [SerializeField] private LayerMask clickerLayerMask;
        private UnityEngine.Camera _camera;
        private SeedingCanvas _seedingCanvas;
        


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = _camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 100f, clickerLayerMask ))
                {
                    print(hit.transform.name);
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        if (hit.transform.TryGetComponent(out IClickableBehaviour clickableBehaviour))
                        {
                            clickableBehaviour.OnClick();
                        }
                        else
                        {
                            _seedingCanvas.HideCanvas();
                        }
                    }
                }
            }
        }

        public void Inject(IService service)
        {
            if (service.GetType() == typeof(SeedingCanvas))
            {
                _seedingCanvas = (SeedingCanvas)service;
            }
            else if (service.GetType() == typeof(CameraController))
            {
                _camera = ((CameraController)service).Camera;
            }
        }
    }
}