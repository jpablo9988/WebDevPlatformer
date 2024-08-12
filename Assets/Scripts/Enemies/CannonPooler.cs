using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/**
 * 
 */
public class CannonPooler : MonoBehaviour
{
    [Header("Cannon Attributes")]
    [SerializeField]
    private float rateOfFire = 2.0f;
    [SerializeField]
    private float timeBeforeBulletReset = 5.0f;
    [SerializeField]
    private float bulletSpeed = 5.0f;
    [Header("Dependencies")]
    [SerializeField]
    private Transform shootingPoint;


    private List<IBulletType> bullets;
    private SpriteRenderer spriteRenderer;
    private float localTimer = 0.0f; // -- in seconds (using Time.deltaTime to count down).

    public bool CanFire { get; set; } = false; 
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        bullets = GetComponentsInChildren<IBulletType>().ToList();
    }

    public void ShootABullet()
    {
        IBulletType bullet = bullets.Where(bullet => bullet.IsInUse == false).FirstOrDefault(); //Checks if any are avaiable.
        if (bullet != null)
        {
            bullet.SpawnPoint = shootingPoint.localPosition;
            bullet.Speed = this.bulletSpeed;
            int xDirection = 1;
            if (spriteRenderer.flipX == false)
            {
                xDirection *= -1;
            }
            bullet.SetMovementDirection(timeBeforeBulletReset, new Vector2(xDirection, 0));
        }
    }
    private void Update()
    {
        if (CanFire)
        {
            if (localTimer <= 0)
            {
                localTimer = rateOfFire; // -- reset timer
                ShootABullet(); // -- shoot any available bullet. 
            }
            localTimer -= Time.deltaTime; // -- count down to 0
        }
    }
   
}
