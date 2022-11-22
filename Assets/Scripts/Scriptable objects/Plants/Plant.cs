using UnityEngine;

namespace Scriptable_objects.Plants
{
    [CreateAssetMenu(menuName = "Create Plant Scriptable Object")]
    public class Plant : ScriptableObject
    {
        public float TimeToGrow;
        public GameObject visualObject;

        public AfterGrowthActions Action;

        public enum AfterGrowthActions
        {
            Nothing,
            Pickup,
            Mow
        }
    }
}