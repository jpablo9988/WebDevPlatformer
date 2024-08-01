using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 * a General Powerup Factory manages the different types of powerup factories with a Dictionary.
 * following Level Up Your Code - Game Programming with Unity's book recommendations. 
 * by: Juan Pablo Amorocho - 301410163. 
 */
public class GeneralPowerupFactory : MonoBehaviour
{
    [Header("Powerup References")]
    [Tooltip("List of powerup types. Needs to be synced with its factory list down below in which order matters.")]
    [SerializeField]
    private List<PowerupType> _powerups;
    [Tooltip("List of powerup factories. They're in charge of creating a powerup.")]
    [SerializeField]
    private List<PowerupFactory> _factories;

    private Dictionary<PowerupType, IPowerupFactory> _powerupsByType;

    private void Awake()
    {
        InitializeDictionary(); //It's called whenever game starts, but can be called wherever if need be. 
    }
    public void InitializeDictionary()
    {
        _powerupsByType = new Dictionary<PowerupType, IPowerupFactory>();
        //Loops through both lists until whichever has its minimum cap. 
        for (int i = 0; i < Mathf.Min(_powerups.Count, _factories.Count); i++) 
        {
            //Assumes both lists are synced which each other for Type = Factory. 
            _powerupsByType[_powerups[i]] = _factories[i];
        }
    }
    public IPowerup GetPowerupByType(PowerupType type, Transform position)
    {
        Debug.Log(type);
        if (_powerupsByType.TryGetValue(type, out IPowerupFactory factory))
        {
            //Debug.Log(type);
            IPowerup instantiatedPowerup = factory.CreatePowerup(position);
            return instantiatedPowerup;
        }
        return null;
    }
    public int MaxAvailablePowerType()
    {
        return _powerups.Count;
    }
}
