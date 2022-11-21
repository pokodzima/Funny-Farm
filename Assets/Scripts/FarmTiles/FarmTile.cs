using Clicker;
using DI;
using Scriptable_objects.Plants;
using TMPro;
using UI;
using UnityEngine;

namespace FarmTiles
{
    public class FarmTile : MonoBehaviour , IClickableBehaviour, IInjectable
    {
        [SerializeField] private TextMeshPro tileStatus;
        private SeedingCanvas _seedingCanvas;
        private Plant _seededPlant;
        public bool IsSeeded { get; private set; }

        public void SeedTile(Plant plantToSeed)
        {
            if (_seededPlant != null) return;
            _seededPlant = plantToSeed;
            tileStatus.text = plantToSeed.name;
            IsSeeded = true;
        }


        public void OnClick()
        {
            _seedingCanvas.SetCanvas(this);
        }
        
        public void Inject(IService service)
        {
            _seedingCanvas = (SeedingCanvas)service;
        }
    }
}