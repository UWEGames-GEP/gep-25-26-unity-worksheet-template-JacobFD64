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
        AddItemToInventory(item);
        item.Pickup();
    }
    protected void HandleDropItem()
    {
        RemoveItemFromInventory(0);
    }
}
