using System.Collections.Generic;
using Camera;
using Character;
using DI;
using UI;
using UnityEngine;

namespace FarmTiles
{
    public class FarmTileFactory : MonoBehaviour, IInjectable
    {
        [SerializeField] private GameObject farmTilePrefab;
        [SerializeField] private float tileSize, tilePadding;
        [SerializeField] private int width, lenght;

        private Vector3 _currentTilePosition;

        private SeedingCanvas _seedingCanvas;
        private CameraController _cameraController;
        private FarmerCharacter _farmerCharacter;
        private ScoreManager _scoreManager;

        public void PlantTiles()
        {
            _currentTilePosition.x = (-width + 1) / 2f * (tileSize + tilePadding);
            for (int w = 0; w < width; w++)
            {
                _currentTilePosition.z = (-lenght + 1) / 2f * (tileSize + tilePadding);
                for (int l = 0; l < lenght; l++)
                {
                    var tile = Instantiate(farmTilePrefab, _currentTilePosition, Quaternion.identity);
                    FarmTile farmTile = tile.GetComponent<FarmTile>();
                    farmTile.Inject(_seedingCanvas);
                    farmTile.Inject(_cameraController);
                    farmTile.Inject(_farmerCharacter);
                    farmTile.Inject(_scoreManager);
                    _currentTilePosition.z += tileSize + tilePadding;
                }

                _currentTilePosition.x += tileSize + tilePadding;
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
            }
            else if (service.GetType() == typeof(ScoreManager))
            {
                _scoreManager = (ScoreManager)service;
            }
        }
    }
}