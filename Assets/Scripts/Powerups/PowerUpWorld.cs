using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWorld : MonoBehaviour
{
    public static PowerUpWorld SpawnPowerUpWorld(Vector3 position ,PowerUp powerUp)
    {
        Transform transform = Instantiate(PowerUpAssets.Instance.PowerUps, position, Quaternion.identity);

        PowerUpWorld powerUpWorld = transform.GetComponent<PowerUpWorld>();
        powerUpWorld.SetPowerup(powerUp);

        return powerUpWorld;
    }


    private PowerUp powerUp;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetPowerup(PowerUp powerUp)
    {
        this.powerUp = powerUp;
        spriteRenderer.sprite = powerUp.GetSprite();
    }
}
