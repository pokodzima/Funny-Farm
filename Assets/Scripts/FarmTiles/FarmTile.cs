using Clicker;
using DI;
using Scriptable_objects.Plants;
using UI;
using UnityEngine;

namespace FarmTiles
{
    public class FarmTile : MonoBehaviour , IClickableBehaviour, IInjectable
    {
        private SeedingCanvas _seedingCanvas;
        private Plant _seededPlant;

        public void SeedTile(Plant plantToSeed)
        {
            if (_seededPlant != null) return;
            _seededPlant = plantToSeed;
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