using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new();

    public IReadOnlyList<Item> Items => items;

    public InventorySlot[] slots = new InventorySlot[10];

    protected GameManager gameManager;

    [SerializeField] InputReader input;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        input.RemoveItemEvent += HandleDropItem;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
                slots[i] = new InventorySlot();
        }
    }

    private void Update()
    {
        this.transform.position = gameManager.characterController.transform.position;

        this.transform.rotation = gameManager.characterController.transform.rotation;
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
    
    public void AddItemToInventory(Item item, InventorySlot slot, int amount = 1)
    {
        var existingItem = item;

        items.Add(existingItem);
        
        slot.hasItem = true;

        //if (IsAnySlotAvailable(slots))
        //{
        //    foreach (InventorySlot slot in slots)
        //    {
        //        if (!slot.IsFilled())
        //        {
        //            AddItemToInventory(itemData, slot);
        //            Pickup();
        //            break;
        //        }
        //        else
        //            continue;
        //    }
        //}

    }

    public void RemoveItemFromInventory(Item item, InventorySlot slot, int amount = 1)
    {
        var existingItem = item;

        if (existingItem == null) { return; }

        Vector3 currentposition = this.transform.position;
        Vector3 forward = this.transform.forward;

        Vector3 newPosition = currentposition + forward;
        newPosition += new Vector3(0, 1, 0);
        existingItem.transform.position = newPosition;

        Quaternion currentRotation = this.transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0 ,180);
        existingItem.transform.rotation = newRotation;

        existingItem.Drop();

        items.Remove(existingItem);
        slot.hasItem = false;

    }

    public void RemoveItemFromInventory(int i )
    {
        if ( i < items.Count)
        {
            RemoveItemFromInventory(items[i], slots[i]);
        }
    }

    public void HandleDropItem()
    {
        RemoveItemFromInventory(items[0], slots[0]);
        // Spawn item in front of player
        Debug.Log("Drop");
    }
}
