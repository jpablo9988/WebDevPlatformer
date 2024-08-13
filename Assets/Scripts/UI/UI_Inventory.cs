
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : SingletonClass<UI_Inventory>
{
    private Inventory inventory;
    [SerializeField]
    private Transform powerUpSlotContainer;
    [SerializeField]
    private Transform powerUpSlotTemplate;

    [SerializeField]
    private Player playerRef;

    private void Start()
    {
        RefreshInventoryPowerUps();
    }
    private void OnEnable()
    {
        inventory = new Inventory();
        inventory.OnPowerUpListChanged += Inventory_OnPowerUpListChanged;
    }
    private void OnDisable()
    {
        inventory.OnPowerUpListChanged -= Inventory_OnPowerUpListChanged;
    }
    private void Inventory_OnPowerUpListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryPowerUps();
    }
    public void UseItem(Player player, IPowerup item)
    {
        item.ActivatePowerup(player);
        this.inventory.RemoveItem(item);
    }
    public void AddItem(IPowerup item)
    {
        this.inventory.AddItem(item);
    }
    private void RefreshInventoryPowerUps()
    {
        foreach(RectTransform child in powerUpSlotContainer)
        {
            Destroy(child.gameObject);
            
        }

        int x = 0;
        int y = 0;
        float powerUpSlotCellSize = 60f;
        foreach (IPowerup powerUp in inventory.GetPowerUpList())
        {
            RectTransform powerUpSlotRectTransform = Instantiate(powerUpSlotTemplate.gameObject, powerUpSlotContainer).GetComponent<RectTransform>();
            powerUpSlotRectTransform.gameObject.SetActive(true);
            InventoryTemplate temp = powerUpSlotRectTransform.gameObject.GetComponent<InventoryTemplate>();
            temp.AssignedItem = powerUp;
            temp.AssignedPlayer = playerRef;
            powerUpSlotRectTransform.anchoredPosition = new Vector2(x * powerUpSlotCellSize, y * powerUpSlotCellSize);
            Image image = temp.GetImage();
            image.sprite = powerUp.GetSprite();
            image.color = powerUp.GetSpriteColor();
            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
        }
    }


}
