using DI;
using UnityEngine;
using UnityEngine.UI;

namespace Camera
{
    public class ResetCameraButton : MonoBehaviour, IInjectable
    {
        private Button _button;

        private CameraController _cameraController;

        // Start is called before the first frame update
        private void Awake()
        {
            _button = GetComponentInChildren<Button>();
        }

        void Start()
        {
            _cameraController.FocusChanged.AddListener(HandleButtonVisibility);
            _button.onClick.AddListener(_cameraController.UnFocusCamera);
        }

        private void HandleButtonVisibility(bool isCameraFocused)
        {
            transform.GetChild(0).gameObject.SetActive(isCameraFocused);
        }

        public void Inject(IService service)
        {
            _cameraController = (CameraController)service;
        }
    }
}