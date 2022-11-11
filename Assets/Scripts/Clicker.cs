using UnityEngine;
using UnityEngine.Events;

public class Clicker : MonoBehaviour
{
    Camera _camera;

    void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent(out IClickableBehaviour clickableBehaviour))
                {
                    clickableBehaviour.OnClick();
                }
            }
        }
    }
}