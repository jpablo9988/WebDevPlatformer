using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFactory : MonoBehaviour, IPowerupFactory
{
    // -- Concrete class reference to powerup. - Prefab // 
   public GameObject PowerupPrefab;

    public IPowerup CreatePowerup(Transform position)
    {
        GameObject pUp = Instantiate(PowerupPrefab, position);
        IPowerup scriptReference = pUp.GetComponent<IPowerup>();
        return scriptReference;
    }
}
