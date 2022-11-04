using UnityEngine;

[CreateAssetMenu(menuName = "Create Plant Scriptable Object")]
public class Plant : ScriptableObject
{
    [SerializeField]
    private GameObject visualPrefab;

    private GameObject _visualGameObject;

    public void SpawnVisual(Vector3 position)
    {
        _visualGameObject = Instantiate(visualPrefab, position, Quaternion.identity);
    }
}