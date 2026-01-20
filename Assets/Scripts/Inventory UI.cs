using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    private void OnEnable()
    {
        RefreshInventory();
    }

    void RefreshInventory()
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
}
