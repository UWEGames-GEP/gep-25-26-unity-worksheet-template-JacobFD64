using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;

    public List<InventoryUISlot> inventoryUISlots = new List<InventoryUISlot>();

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

    }
    private void Start()
    {
        inventory.RemoveItemEvent += HandleRemoveItem;


        
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
}
