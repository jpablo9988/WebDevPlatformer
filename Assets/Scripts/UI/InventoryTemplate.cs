using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTemplate : MonoBehaviour
{
    public IPowerup AssignedItem { get; set; }
    public Player AssignedPlayer { get; set; }
    [SerializeField]
    private Image imageField;
    public Image GetImage()
    {
        return imageField;
    }
    public void ActivatePowerup()
    {
        UI_Inventory.Instance.UseItem(AssignedPlayer, AssignedItem);
    }
    
}
