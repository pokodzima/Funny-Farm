using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmTileFactory : MonoBehaviour, IInjectable
{
    [SerializeField] private GameObject farmTilePrefab;
    [SerializeField] private float tileSize, tilePadding;
    [SerializeField] private int width, lenght;

    private Vector3 _currentTilePosition;

    private SeedingCanvas _seedingCanvas;

    private void PlantTiles()
    {
        _currentTilePosition.x = (-width + 1) / 2f * (tileSize + tilePadding);
        for (int w = 0; w < width; w++)
        {
            _currentTilePosition.z = (-lenght + 1) / 2f * (tileSize + tilePadding);
            for (int l = 0; l < lenght; l++)
            {
                var tile = Instantiate(farmTilePrefab, _currentTilePosition, Quaternion.identity);
                tile.GetComponent<FarmTile>().SeedingCanvas = _seedingCanvas;
                _currentTilePosition.z += tileSize + tilePadding;
            }

            _currentTilePosition.x += tileSize + tilePadding;
        }
    }


    public void Inject(IService service)
    {
        _seedingCanvas = (SeedingCanvas)service;
        PlantTiles();
    }
}