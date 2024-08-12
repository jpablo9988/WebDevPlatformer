using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletType
{
    public void SetMovementDirection(float timerUntilDone, Vector2 direction);
    public void ResetBullet();

    public Vector2 SpawnPoint { get; set; }
    public bool IsInUse { get; set; }
    public float Speed { get; set; }
}
