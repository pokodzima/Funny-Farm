using System;
using System.Globalization;
using Camera;
using Character;
using Clicker;
using DI;
using Scriptable_objects.Plants;
using TMPro;
using UI;
using UnityEngine;

namespace FarmTiles
{
    public class FarmTile : MonoBehaviour, IClickableBehaviour, IInjectable
    {
        [SerializeField] private TextMeshPro tileStatus;

        public enum SeedState
        {
            Empty,
            Seeded,
            Grown
        }

        public SeedState State { get; private set; }
        private SeedingCanvas _seedingCanvas;
        private CameraController _cameraController;
        private FarmerCharacter _farmerCharacter;
        private ScoreManager _scoreManager;
        private Plant _seededPlant;
        private float _growTimer;
        private GameObject _visualPlant;


        public void SeedTile(Plant plantToSeed)
        {
            if (_seededPlant != null) return;
            _seededPlant = plantToSeed;
            tileStatus.text = plantToSeed.name;
            State = SeedState.Seeded;

            _growTimer = _seededPlant.TimeToGrow;
            _visualPlant = Instantiate(_seededPlant.visualObject, transform.position, transform.rotation, transform);
            _visualPlant.GetComponentInChildren<ClickablePlant>().FarmTile = this;
            _visualPlant.GetComponentInChildren<ClickablePlant>().FarmerCharacter = _farmerCharacter;
            var scale = _visualPlant.transform.localScale;
            scale.y = 0;
            _visualPlant.transform.localScale = scale;

            _cameraController.FocusCamera(transform.position);
        }

        private void Update()
        {
            switch (State)
            {
                case SeedState.Seeded:
                    _growTimer -= Time.deltaTime;
                    var growTime = (_seededPlant.TimeToGrow - _growTimer) / _seededPlant.TimeToGrow;
                    var scale = _visualPlant.transform.localScale;
                    scale.y = Mathf.Lerp(0f, 1f, growTime);
                    _visualPlant.transform.localScale = scale;
                    if (_growTimer <= 0f)
                    {
                        State = SeedState.Grown;
                        tileStatus.text = _seededPlant.name;
                        _scoreManager.AddExperience((int)_seededPlant.TimeToGrow);
                        return;
                    }

                    tileStatus.text = ((int)_growTimer).ToString(CultureInfo.InvariantCulture);
                    break;
            }
        }


        public void OnClick()
        {
            switch (State)
            {
                case SeedState.Empty:
                    _seedingCanvas.SetCanvas(this);
                    break;
            }
        }

        public void TryMowPlant()
        {
            if (State != SeedState.Grown)
            {
                return;
            }

            if (_seededPlant.Action == Plant.AfterGrowthActions.Nothing)
            {
                return;
            }
            else
            {
                if (_seededPlant.name == "Carrot")
                {
                    _scoreManager.AddCarrot();
                }
                
                tileStatus.text = "";
                Destroy(_visualPlant);
                _growTimer = 0f;
                State = SeedState.Empty;
                _seededPlant = null;
            }
        }

        public void Inject(IService service)
        {
            if (service.GetType() == typeof(SeedingCanvas))
            {
                _seedingCanvas = (SeedingCanvas)service;
            }
            else if (service.GetType() == typeof(CameraController))
            {
                _cameraController = (CameraController)service;
            }
            else if (service.GetType() == typeof(FarmerCharacter))
            {
                _farmerCharacter = (FarmerCharacter)service;
            } else if (service.GetType() == typeof(ScoreManager))
            {
                _scoreManager = (ScoreManager)service;
            }
        }
    }
}