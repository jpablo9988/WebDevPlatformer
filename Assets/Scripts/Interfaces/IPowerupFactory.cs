using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Interface that marks a specific powerup factory. 
 */
public interface IPowerupFactory
{
    public IPowerup CreatePowerup(Transform position);
}

