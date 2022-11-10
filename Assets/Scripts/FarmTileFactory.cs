using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTileFactory : MonoBehaviour
{
    [SerializeField] private GameObject farmTilePrefab;
    [SerializeField] private float tileSize, tilePadding;
    [SerializeField] private int width, lenght;

    private Vector3 _currentTilePosition;

    void Awake()
    {
        _currentTilePosition.x = (-width + 1) / 2f * (tileSize + tilePadding);
        for (int w = 0; w < width; w++)
        {
            _currentTilePosition.z = (-lenght + 1) / 2f * (tileSize + tilePadding);
            for (int l = 0; l < lenght; l++)
            {
                Instantiate(farmTilePrefab, _currentTilePosition, Quaternion.identity);
                _currentTilePosition.z += tileSize + tilePadding;
            }

            _currentTilePosition.x += tileSize + tilePadding;
        }
    }
}