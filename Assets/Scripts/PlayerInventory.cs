using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventory : Inventory
{
    
    [SerializeField] private PlayerCharacterController controller;

    [SerializeField] private GridLayout grid;

    private int SlotCount => grid.rows * grid.columns;

    public InventorySlot[] slots;

    public event Action<Item, int > PickUpItemToSlotEvent;

    [SerializeField] private GameObject slot_prefab;

    private void Start()
    {
        controller.CollideWithItemEvent += HandleItemCollision;

        slots = new InventorySlot[SlotCount];

        // this gets the x and y index for each slot
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new InventorySlot();
            slots[i].x = Mathf.FloorToInt(i % grid.rows);
            slots[i].y = Mathf.FloorToInt(i / grid.columns);
        }

    }

    public override void RemoveItemFromInventory(Item item)
    {
        base.RemoveItemFromInventory(item);
        RemoveItemEvent?.Invoke(item);
    }

    private void HandleItemCollision(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsFilled())
            {
                continue;
            }
            else if (checkSurroundingSlots(i, item, grid))
            {
                PickUpItemToSlotEvent?.Invoke(item, i);
                AddItemToSlot(item, i);
                item.Pickup();
                return;
            }
        }
    }
    public bool checkSurroundingSlots(int slot_index, Item item, GridLayout grid)
    {
        for (int j = 0; j < item.data.horizontalSlots; j++)
        {
            for (int k = 0; k < item.data.verticalSlots; k++)
            {
                // get the x and y for the slot being checked
                int x = slots[slot_index].x + j;
                int y = slots[slot_index].y + k;
                
                int index = slot_index + j + k * grid.columns;

                // checking if the slot is in the bounds of the grid
                if (x >= grid.columns || x < 0 || y >= grid.rows || y < 0)
                {
                    return false;
                }
                if (slots[index].IsFilled())
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void AddItemToSlot(Item item, int slot)
    {

        for (int j = 0; j < item.data.horizontalSlots; j++)
        {
            for (int k = 0; k < item.data.verticalSlots; k++)
            {
                int index = slot + j + k * grid.columns;

                slots[index].hasItem = true;
            }
        }
    }    
    public void RemoveItemFromSlot(Item item, int slot)
    {
        for (int j = 0; j < item.data.horizontalSlots; j++)
        {
            for (int k = 0; k < item.data.verticalSlots; k++)
            {
                int index = slot + j + k * grid.columns;

                slots[index].hasItem = false;
            }
        }
    }

    public void RemoveItem(Item item, int slot)
    {
        RemoveItemFromSlot(item, slot);
        RemoveItemFromInventory(item);
    }
}
