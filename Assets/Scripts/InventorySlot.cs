using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InventorySlot
{
    private ItemData itemData;

    private InventoryUISlot slot;

    public bool hasItem;

    InventorySlot (InventoryUISlot UI)
    {
        slot = UI;
    }
    public void AddItemToSlot(ItemData item)
    {
        
        itemData = item;
    }

    public bool IsFilled()
    {
        if (hasItem)
        {
            return true;
        }
        return false;
    }


}
