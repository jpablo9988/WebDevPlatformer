using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp
{
    public enum PowerupType
    {
        SmallHealth,
        BigHealth,
        FasterMovement
    }

    public PowerupType powerUpType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (powerUpType)
        {
            default:
            case PowerupType.SmallHealth: return PowerUpAssets.Instance.smallHealthSprite;
            case PowerupType.BigHealth: return PowerUpAssets.Instance.bigHealthSprite;
            case PowerupType.FasterMovement: return PowerUpAssets.Instance.fasterMovementSprite;
        }
    }

    public bool IsStackable()
    {
        switch (powerUpType)
        {
            default :
            case PowerupType.SmallHealth:
            case PowerupType.BigHealth: 
                return false;
            case PowerupType.FasterMovement: 
                return true;
        }
    }
}
