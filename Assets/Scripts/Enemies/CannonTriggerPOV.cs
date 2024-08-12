using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTriggerPOV : MonoBehaviour
{
    [SerializeField]
    private CannonPooler pooler;
    [SerializeField]
    private string PlayerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision) // -- when player enters frontal area
    {
        if (collision.gameObject.CompareTag(PlayerTag))
        {
            pooler.CanFire = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerTag))
        {
            pooler.CanFire = false;
        }
    }
}
