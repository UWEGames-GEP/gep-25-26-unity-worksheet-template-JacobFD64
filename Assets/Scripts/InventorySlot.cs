using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InventorySlot
{
    private ItemData itemData;

    public bool hasItem;

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
