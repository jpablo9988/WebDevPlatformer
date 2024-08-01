using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPowerup : MonoBehaviour, IPowerup
{
    [SerializeField]
    private int amount;
    public void ActivatePowerup(Player player)
    {
        if (amount <= 0) player.RestoreAllHealth();
        player.ModifyHealth(amount);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            ActivatePowerup(player);
            Destroy(this.gameObject);
        }
    }
}
