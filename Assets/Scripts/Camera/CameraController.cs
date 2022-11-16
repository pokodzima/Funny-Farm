using DI;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour, IService
    {
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
