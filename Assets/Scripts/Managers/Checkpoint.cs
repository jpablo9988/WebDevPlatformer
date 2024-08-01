using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public delegate void ProcessCheckpoint(Checkpoint cpoint);
    public static event ProcessCheckpoint RegisterCheckpoint;

    
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {             RegisterCheckpoint?.Invoke(this);
        }
    }
}
