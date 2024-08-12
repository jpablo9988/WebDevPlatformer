using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPowerup : AbstractPowerup
{
    [SerializeField]
    private int amount;

    public override void ActivatePowerup(Player player)
    {
        if (amount <= 0) player.RestoreAllHealth();
        player.ModifyHealth(amount);
    }
}
