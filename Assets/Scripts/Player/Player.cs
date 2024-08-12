using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealthPoints = 3;
    [SerializeField]
    private Image healthFill;
    [SerializeField]
    private PlayerMovement movementManager;
    [SerializeField]
    private float invisiblityTimer = 1.0f;
    [SerializeField]
    private float alphaWhenHit = 0.5f;

    private int currHealthPoints;
    private bool isInvinsible = false;

    private void Start()
    {
        currHealthPoints = maxHealthPoints;
        healthFill.fillAmount = 1;
    }
    public void FellToPit()
    {
        // Go to current checkpoint's position. 
        if (!isInvinsible)
        {
            ModifyHealth(-1);
        }
        this.transform.position = GameMaster.Instance.ActiveCheckpoint.transform.position;
    }

    public void ModifyHealth(int amount)
    {
        //If it has reached the max, returns.
        if (currHealthPoints == maxHealthPoints && amount > 0) return;
        currHealthPoints += amount;
        healthFill.fillAmount = (float)currHealthPoints / maxHealthPoints;
        if (currHealthPoints <= 0)
        {
            GameMaster.Instance.GameOver();
        }

    }
    public void RestoreAllHealth()
    {
        currHealthPoints = maxHealthPoints;
    }

    public void AcceleratePlayer(float duration, float speedAdd)
    {
        movementManager.AdditiveSpeed(speedAdd);
        
        StartCoroutine(GeneralTools.Instance.Timer(duration, movementManager.ResetSpeed));
    }
    public void GetHit(int amount, Vector2 enemyPosition, Vector2 pushbackIntensity)
    {
        if (!isInvinsible)
        {
            ModifyHealth(amount);
            movementManager.ApplyImpulse(enemyPosition, pushbackIntensity);
            StartCoroutine(InvinsibleToNormal());
            
        }
    }

    private IEnumerator InvinsibleToNormal()
    {
        // -- modify alpha of spriteRenderer color. -- //
        isInvinsible = true;
        Color c = movementManager.GetRenderer().color;
        c.a = alphaWhenHit;
        movementManager.GetRenderer().color = c;
        yield return new WaitForSeconds(invisiblityTimer); // -- wait for X seconds
        c.a = 1.0f;
        movementManager.GetRenderer().color = c; // return spriteColor to normal
        isInvinsible = false;
    }
}
