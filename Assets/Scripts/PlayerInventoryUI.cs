using System.Collections.Generic;
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
        inventory.PickUpItemEvent += HandlePickUpItem;
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
        Debug.Log("picked");

        GameObject itemUI = Instantiate(itemUIPrefab, transform);

        itemUI.GetComponent<ItemUI>().setItem(item);

        itemUIs.Add(itemUI);
    }
}
