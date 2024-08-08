using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [SerializeField]
    private EnemyAI aiRef;
    [SerializeField]
    private string PlayerTag = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            aiRef.FoundTarget(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            aiRef.LostTarget();
        }
    }
}
