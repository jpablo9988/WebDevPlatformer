using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField]
    private Checkpoint activeCheckpoint;
    private void OnEnable()
    {
        Checkpoint.RegisterCheckpoint += ProcessCheckpoint;
    }
    private void OnDisable()
    {
        Checkpoint.RegisterCheckpoint -= ProcessCheckpoint;
    }
    private void ProcessCheckpoint (Checkpoint newcPoint)
    {
        activeCheckpoint = newcPoint;
    }
    public Checkpoint GetActiveCheckpoint()
    {
        return activeCheckpoint;
    }
}
