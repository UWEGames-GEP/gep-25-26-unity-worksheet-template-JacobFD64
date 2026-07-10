using System;
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

    private List<InventoryUISlot> inventoryUISlots = new List<InventoryUISlot>();

    public List<ItemUI> itemUIs = new List<ItemUI>();

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
        inventory.PickUpItemToSlotEvent += HandlePickUpItem;

    }
    private void Update()
    {
        itemUIs.RemoveAll(item => item == null);
    }

    private void HandlePickUpItem(Item item, int slot_index)
    {
        GameObject itemUI = Instantiate(itemUIPrefab, transform);

        ItemUI ui = itemUI.GetComponent<ItemUI>();

        ui.grid = GetComponentInChildren<GridLayout>();

        ui.inv = inventory;

        ui.currentSlotIndex = slot_index;

        ui.setItem(item);

        ui.MoveItemEvent += HandleMoveItem;

        float imageStartPositionx = inventoryUISlots[slot_index].transform.position.x;
        float imageStartPositiony = inventoryUISlots[slot_index].transform.position.y;

        ui.rect.transform.position = new Vector2(imageStartPositionx, imageStartPositiony);

        itemUIs.Add(itemUI.GetComponent<ItemUI>());
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
    }

    private void HandleMoveItem(int index, ItemUI ui)
    {
        float imageStartPositionx = inventoryUISlots[index].transform.position.x;
        float imageStartPositiony = inventoryUISlots[index].transform.position.y;

        ui.rect.transform.position = new Vector2(imageStartPositionx, imageStartPositiony);
    }

   
}
