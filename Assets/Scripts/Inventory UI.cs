using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;

    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    private void Awake()
    {
        inventoryUIButtons.Clear();

        foreach (Transform child in transform)
        {
            inventoryUIButtons.Add(child.gameObject);
        }
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
        foreach (var button in inventoryUIButtons)
        {
            button.SetActive(false);
        }

        for (int i = 0; i < inventory.Items.Count; i++)
        {
            if (i < inventoryUIButtons.Count)
            {
                InventoryUIButton button = inventoryUIButtons[i].GetComponent<InventoryUIButton>();
                Item item = inventory.Items[i];

                button.gameObject.SetActive(true);
                button.SetButton(item);
            }
        }
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
