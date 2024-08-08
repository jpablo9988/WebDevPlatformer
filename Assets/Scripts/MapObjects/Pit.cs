using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player p = collision.GetComponent<Player>();
            p.FellToPit();
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
