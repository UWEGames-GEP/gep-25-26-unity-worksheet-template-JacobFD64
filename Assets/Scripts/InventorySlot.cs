

public class InventorySlot
{
    private ItemData itemData;

    private InventoryUISlot slot;

    public bool hasItem;

    public int x;

    public int y;


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
