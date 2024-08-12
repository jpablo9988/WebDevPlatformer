using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnPowerUpListChanged;

    private List<PowerUp> powerUpList;
    
    public Inventory()
    {
        powerUpList = new List<PowerUp>();

        AddItem(new PowerUp { powerUpType = PowerUp.PowerupType.FasterMovement, amount = 1 });
        AddItem(new PowerUp { powerUpType = PowerUp.PowerupType.SmallHealth, amount = 1 });
        AddItem(new PowerUp { powerUpType = PowerUp.PowerupType.BigHealth, amount = 1 });

        Debug.Log(powerUpList.Count);
    }

    public void AddItem(PowerUp powerUp)
    {
        if (powerUp.IsStackable())
        {
            bool powerUpAlreadyInInventory = false;
            foreach (PowerUp inventoryPowerUp in powerUpList)
            {
                if(inventoryPowerUp.powerUpType == powerUp.powerUpType)
                {
                    inventoryPowerUp.amount += powerUp.amount;
;    
                }
            }
            if (!powerUpAlreadyInInventory)
            {
                powerUpList.Add(powerUp);
            }
        }
        else
        {
            powerUpList.Add(powerUp);
        }
        
        OnPowerUpListChanged?.Invoke(this, EventArgs.Empty);

    }

    public List<PowerUp> GetPowerUpList()
    {
        return powerUpList;
    }
}
