using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> powerPositions;
    [SerializeField]
    private GeneralPowerupFactory powerupFactory;

    private List<bool> positionHasItem;

    private int NoPowerups;
    void Start()
    {
        NoPowerups = powerupFactory.MaxAvailablePowerType(); // +1 as we want a Count.
        SpawnPowerupsRandomly();
    }

    public void SpawnPowerupsRandomly()
    {
        
        for(int i = 0; i < powerPositions.Count; i++)
        {
            PowerupType randomType = (PowerupType)UnityEngine.Random.Range(0, NoPowerups);
            powerupFactory.GetPowerupByType(randomType, powerPositions[i]);
        }
    }
}
