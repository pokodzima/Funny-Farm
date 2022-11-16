using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private SeedingCanvas seedingCanvas;

    private void Awake()
    {
        var tiles = FindObjectsOfType<FarmTileFactory>();
        foreach (var injectable in tiles.OfType<IInjectable>())
        {
            injectable.Inject(seedingCanvas);
        }
    }
}