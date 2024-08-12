using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform powerUpSlotContainer;
    private Transform powerUpSlotTemplate;

    private void Awake()
    {
        powerUpSlotContainer = transform.Find("powerUpSlotContainer");
        powerUpSlotTemplate = powerUpSlotContainer.Find("powerUpSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnPowerUpListChanged += Inventory_OnPowerUpListChanged;

        RefreshInventoryPowerUps();
    }

    private void Inventory_OnPowerUpListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryPowerUps();
    }

    private void RefreshInventoryPowerUps()
    {
        foreach(Transform child in powerUpSlotContainer)
        {
            if (child == powerUpSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float powerUpSlotCellSize = 45f;
        foreach (PowerUp powerUp in inventory.GetPowerUpList())
        {
            RectTransform powerUpSlotRectTransform = Instantiate(powerUpSlotTemplate, powerUpSlotContainer).GetComponent<RectTransform>();
            powerUpSlotRectTransform.gameObject.SetActive(true);

            powerUpSlotRectTransform.anchoredPosition = new Vector2(x * powerUpSlotCellSize, y * powerUpSlotCellSize);
            Image image = powerUpSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = powerUp.GetSprite();

            TextMeshProUGUI uiText = powerUpSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if(powerUp.amount > 1)
            {
                uiText.SetText(powerUp.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
            

            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
        }
    }


}
