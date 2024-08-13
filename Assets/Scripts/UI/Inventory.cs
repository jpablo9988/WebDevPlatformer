using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnPowerUpListChanged;

    private List<IPowerup> powerUpList;
    
    public Inventory()
    {
        powerUpList = new List<IPowerup>();
    }

    public void AddItem(IPowerup powerUp)
    {
        powerUpList.Add(powerUp);        
        OnPowerUpListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveItem(IPowerup item)
    {
        powerUpList.Remove(item);
        OnPowerUpListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<IPowerup> GetPowerUpList()
    {
        return powerUpList;
    }
}
