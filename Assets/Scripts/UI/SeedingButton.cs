using System;
using DI;
using Scriptable_objects.Plants;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class SeedingButton : MonoBehaviour, IInjectable
    {
        [SerializeField] private Plant seedingTypeOfPlant;
        private SeedingCanvas _seedingCanvas;
        

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(PlantSeed);
        }

        private void PlantSeed()
        {
            _seedingCanvas.CurrentTile.SeedTile(seedingTypeOfPlant);
        }

        public void Inject(IService service)
        {
            _seedingCanvas = (SeedingCanvas)service;
        }
    }
}
