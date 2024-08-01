using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Interface that activates a specific powerup towards a player. 
 */
public interface IPowerup
{
    public void ActivatePowerup(Player player);
}
