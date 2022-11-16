using DI;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Clicker
{
    public class Clicker : MonoBehaviour, IInjectable
    {
        private UnityEngine.Camera _camera;
        private SeedingCanvas _seedingCanvas;
        

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = _camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        if (hit.transform.TryGetComponent(out IClickableBehaviour clickableBehaviour))
                        {
                            clickableBehaviour.OnClick();
                        }
                    }
                    else
                    {
                        _seedingCanvas.HideCanvas();
                    }
                }
            }
        }

        public void Inject(IService service)
        {
            _seedingCanvas = (SeedingCanvas)service;
        }
    }
}