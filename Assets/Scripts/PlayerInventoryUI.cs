using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;

    public List<InventoryUISlot> inventoryUISlots = new List<InventoryUISlot>();

    public List<GameObject> itemUIs = new List<GameObject>();

    public GameObject itemUIPrefab;

    private CanvasGroup group;

    private void OnValidate()
    {
        inventoryUISlots.Clear();

        InventoryUISlot[] slots = GetComponentsInChildren<InventoryUISlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            inventoryUISlots.Add(slots[i]);
        }

    }
    private void Awake()
    {
        GameManager.instance.OnStateChangedEvent += HandleStateChanged;

        group = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        inventory.RemoveItemEvent += HandleRemoveItem;
        inventory.PickUpItemEvent += HandlePickUpItem;

    }

    private void Update()
    {
        
    }
    private void OnEnable()
    {
        RefreshInventory();

        
    }

    private void RefreshInventory()
    {

    }

    public void OnInventoryUIButton(int i)
    {
        inventory.RemoveItemFromInventory(i);
        RefreshInventory();
    }

    public void HandleRemoveItem()
    {
        RefreshInventory();
    }

    private void HandlePickUpItem(Item item)
    {
        GameObject itemUI = Instantiate(itemUIPrefab, transform);

        ItemUI ui = itemUI.GetComponent<ItemUI>();

        ui.grid = GetComponentInChildren<GridLayout>();

        ui.setItem(item);

        itemUIs.Add(itemUI);
    }

    private void HandleStateChanged(GameState state)
    {
        if (state is GameplayState)
        {
            group.alpha = 0;
        }
        else if (state is PauseState)
        {
            group.alpha = 1;
        }

        Debug.Log("State Changed");
    }

   
}
