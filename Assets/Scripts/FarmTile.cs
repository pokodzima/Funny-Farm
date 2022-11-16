using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour , IClickableBehaviour
{
    public SeedingCanvas SeedingCanvas; 
    private Plant _seededPlant;

    public void SeedTile(Plant plantToSeed)
    {
        if (_seededPlant != null) return;
        _seededPlant = plantToSeed;
        _seededPlant.SpawnVisual(transform.position);
    }


    public void OnClick()
    {
        print("Clicked");
    }
}