using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPowerup : MonoBehaviour, IPowerup
{
    [SerializeField]
    private float duration;

    [SerializeField]
    private float speedAccelerator;
    public void ActivatePowerup(Player player)
    {
        player.AcceleratePlayer(duration, speedAccelerator);
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
