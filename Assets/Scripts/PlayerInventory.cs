using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventory : Inventory
{

    [SerializeField] private InputReader input;

    [SerializeField] private PlayerCharacterController controller;

    public InventorySlot[] slots = new InventorySlot[10];

    public event Action RemoveItemEvent;

    private void Start()
    {
        input.DropItemEvent += HandleDropItem;
        controller.CollideWithItemEvent += HandleItemCollision;

    }

    public override void RemoveItemFromInventory(Item item, int amount = 1)
    {
        base.RemoveItemFromInventory(item, amount);
        RemoveItemEvent?.Invoke();
    }

    private void HandleItemCollision(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].hasItem)
            {
                for(int j = 0; j < item.data.horizontalSlots; j++)
                {
                    for (int k = 0; k < item.data.verticalSlots; k++)
                    {
                        if (slots[i * k + j].hasItem)
                        {
                            return;
                        }
                    }
                }
                AddItemToInventory(item);
                item.Pickup();
            }
        }
    }
    protected void HandleDropItem()
    {
        RemoveItemFromInventory(0);
    }
}
