using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPowerup : MonoBehaviour, IPowerup
{
    [SerializeField]
    private bool respawns = false;
    [SerializeField]
    private float timerUntilRespawn = 5.0f;

    private Collider2D currCollier;
    private SpriteRenderer sprite;
    protected virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        currCollier = GetComponent<Collider2D>();
    }
    public virtual void ActivatePowerup(Player player)
    {
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            // In here, instead of activating the powerup, store it on your inventory. (This is up to you)
            // If it were me, have an inventoryManager singleton where you can add this TYPE of powerup to it.
            // On the inventory, call upon ActivatePowerup when the user selects a powerup and uses it with a button or smtn
            //ActivatePowerup(player);
            UI_Inventory.Instance.AddItem(this);
            if (!respawns)
            {
                DisablePowerup();
            }
            else
            {
                DisablePowerup(timerUntilRespawn);
            }
        }
    }
    public virtual void DisablePowerup(float timer = -1.0f)
    {
        if (timer >= 0.0f) // 
        {
            sprite.enabled = false;
            currCollier.enabled = false;
            StartCoroutine(GeneralTools.Instance.Timer(timer, EnablePowerup));
        }
        else
        {
            sprite.enabled = false;
            currCollier.enabled = false;
        }
    }
    protected virtual void EnablePowerup()
    {
        sprite.enabled = true;
        currCollier.enabled = true;
    }

    public virtual Sprite GetSprite()
    {
        return this.sprite.sprite;
    }
    public virtual Color GetSpriteColor()
    {
        return this.sprite.color;
    }
}
