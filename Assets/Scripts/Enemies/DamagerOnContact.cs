using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerOnContact : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private string playerTag = "Player";
    [SerializeField]
    private int damageDone = 1;
    [SerializeField]
    private Vector2 pushbackIntensity;

    public int DamageDone { get { return damageDone; } set { damageDone = value; } }

    private void OnCollisionEnter2D(Collision2D collision) // -- enters in a collision
    {
        if (collision.gameObject.CompareTag(playerTag)) // -- if is a player...
        {
           Player hitPlayer = collision.gameObject.GetComponent<Player>();
           hitPlayer.GetHit(-damageDone, this.transform.position, pushbackIntensity);
        }
    }
}
