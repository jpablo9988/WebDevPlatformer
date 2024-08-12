using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPowerup : AbstractPowerup
{
    [SerializeField]
    private float duration;

    [SerializeField]
    private float speedAccelerator;
    public override void ActivatePowerup(Player player)
    {
        player.AcceleratePlayer(duration, speedAccelerator);
    }
}
