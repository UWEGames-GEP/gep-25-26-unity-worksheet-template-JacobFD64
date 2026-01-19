using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> items = new();

    public InventorySlot[] slots = new InventorySlot[10];

    protected GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
                slots[i] = new InventorySlot();
        }
    }

    public bool IsAnySlotAvailable(InventorySlot[] slots)
    {
        if (slots == null)
        {
            return false;
        }

        foreach (InventorySlot slot in slots)
        {
            if (!slot.IsFilled())
            {
                return true;
            } 
        }
        return false;
    }

    public InventorySlot GetEarliestAvailableSlot(InventorySlot[] slots)
    {
        foreach (InventorySlot slot in slots)
        {
            if (!slot.IsFilled())
                continue;
            else
            {
                InventorySlot availableSlot = slot;
                return availableSlot;
            }
        }
        return null;

    }
    
    public void AddItemToInventory(ItemData itemData, InventorySlot slot, int amount = 1)
    {
        var existingItem = itemData;

        items.Add(existingItem);
        
        slot.hasItem = true;

    }

    public void RemoveItemFromInventory(ItemData itemData, InventorySlot slot, int amount = 1)
    {
        var existingItem = itemData;

        if (existingItem == null) { return; }
        
        items.Remove(existingItem);
        slot.hasItem = false;

    }
}
