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

    private int currHealthPoints;

    private void Start()
    {
        currHealthPoints = maxHealthPoints;
        healthFill.fillAmount = 1;
    }
    public void FellToPit()
    {
        // Go to current checkpoint's position. 
        ModifyHealth(-1);
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
}
