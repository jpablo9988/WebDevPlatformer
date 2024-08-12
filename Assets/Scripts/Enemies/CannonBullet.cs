using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour, IBulletType
{
    [Header("Attributes")]
    [SerializeField]
    private int damageOnHit = 1;

    [Header ("Dependencies")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private TrailRenderer trail;
    [SerializeField]
    private Collider2D collider2d;

    public Vector2 SpawnPoint { get; set; }
    public bool IsInUse { get; set; } = false;

    public float Speed { get; set; } = 1.0f;

    [SerializeField]
    private DamagerOnContact collisionManager;

    private void Start()
    {
        if (collisionManager != null)
        {
            collisionManager.DamageDone = damageOnHit;
        }
    }
    public void ResetBullet()
    {
        // -- disable functionality and visuals
        trail.emitting = false;
        ActivateBullet(false);
        rb2d.velocity = new();
        this.transform.localPosition = SpawnPoint;
    }

    public void SetMovementDirection(float timerUntilDone, Vector2 direction)
    {
        ActivateBullet(true);
        StartCoroutine(GeneralTools.Instance.Timer(timerUntilDone, ResetBullet));
        rb2d.velocity = direction * Speed;
        trail.emitting = true;
    }
    private void ActivateBullet(bool b)
    {
        IsInUse = b;
        collider2d.enabled = b;
        spriteRenderer.enabled = b;
    }
}
