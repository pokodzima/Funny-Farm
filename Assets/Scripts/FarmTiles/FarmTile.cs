using System;
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
            var scale = _visualPlant.transform.localScale;
            scale.y = 0;
            _visualPlant.transform.localScale = scale;
        }

        private void Update()
        {
            switch (State)
            {
                case SeedState.Seeded:
                    print(_growTimer);
                    _growTimer -= Time.deltaTime;
                    var scale = _visualPlant.transform.localScale;
                    scale.y = Mathf.Lerp(0f, 1f, (_seededPlant.TimeToGrow - _growTimer) / _seededPlant.TimeToGrow);
                    _visualPlant.transform.localScale = scale;
                    if (_growTimer <= 0f)
                    {
                        State = SeedState.Grown;
                    }

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
                case SeedState.Grown:
                    State = SeedState.Empty;
                    _seededPlant = null;
                    tileStatus.text = "No Plant";
                    Destroy(_visualPlant);
                    break;
            }
        }

        public void Inject(IService service)
        {
            _seedingCanvas = (SeedingCanvas)service;
        }
    }
}