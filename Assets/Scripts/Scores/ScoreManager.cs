using System;
using System.Collections;
using System.Collections.Generic;
using DI;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IService
{
    private int _carrotsCount;
    private int _experienceCount;

    [SerializeField]private TextMeshProUGUI carrotsText;
    [SerializeField] private TextMeshProUGUI expText;
    

    public void AddCarrot()
    {
        _carrotsCount++;
        carrotsText.text = _carrotsCount.ToString();
    }

    public void AddExperience(int experienceCount)
    {
        _experienceCount += experienceCount;
        expText.text = _experienceCount.ToString();
    }
}
