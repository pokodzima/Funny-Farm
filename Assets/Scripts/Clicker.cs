using UnityEngine;
using UnityEngine.Events;

public class Clicker : MonoBehaviour
{
    public UnityEvent OnMouseClicked;

    private void OnMouseDown()
    {
        OnMouseClicked.Invoke();
    }
}
