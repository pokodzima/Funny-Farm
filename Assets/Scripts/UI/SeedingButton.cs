using System;
using Character;
using DI;
using FarmTiles;
using Scriptable_objects.Plants;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class SeedingButton : MonoBehaviour, IInjectable
    {
        [SerializeField] private Plant seedingTypeOfPlant;
        private SeedingCanvas _seedingCanvas;
        private FarmerCharacter _farmerCharacter;


        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(PlantSeed);
        }

        private void PlantSeed()
        {
            if (_seedingCanvas.CurrentTile.State == FarmTile.SeedState.Seeded ||
                _seedingCanvas.CurrentTile.State == FarmTile.SeedState.Grown)
            {
                return;
            }

            _farmerCharacter.SeedTile(_seedingCanvas.CurrentTile, seedingTypeOfPlant);
            _seedingCanvas.HideCanvas();
        }

        public void Inject(IService service)
        {
            if (service.GetType() == typeof(SeedingCanvas))
            {
                _seedingCanvas = (SeedingCanvas)service;
            }
            else if (service.GetType() == typeof(FarmerCharacter))
            {
                _farmerCharacter = (FarmerCharacter)service;
            }
        }
    }
}