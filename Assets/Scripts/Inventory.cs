using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items = new(); 

    protected GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void AddItemToInventory(ItemData itemData, int amount = 1)
    {
        var existingItem = items.Find(i => i.data == itemData);
        
        if (existingItem == null) { return; }

        items.Add(new Item(itemData, amount));

    }

    public void RemoveItemFromInventory(ItemData itemData, int amount = 1)
    {
        var existingItem = items.Find(i => i.data == itemData);

        if (existingItem == null) { return; }

        existingItem.amount =- amount;

        if (existingItem.amount >= 0)
        {
            items.Remove(existingItem);
        }
    }
}
