using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public abstract class Inventory : MonoBehaviour
{
    private List<Item> items = new();

    public List<Item> Items => items;

    public event Action <Item>PickUpItemEvent;

    private void Start()
    {

    }

    protected void AddItemToInventory(Item item, int amount = 1)
    {
        var existingItem = item;

        items.Add(existingItem);

        PickUpItemEvent?.Invoke(item);

    }

    public virtual void RemoveItemFromInventory(Item item, int amount = 1)
    {
        var existingItem = item;

        if (existingItem == null) { return; }

        Vector3 currentposition = this.transform.position;
        Vector3 forward = this.transform.forward;

        Vector3 newPosition = currentposition + forward;
        existingItem.transform.position = newPosition;

        Quaternion newRotation = this.transform.rotation;
        existingItem.transform.rotation = newRotation;

        existingItem.Drop();

        items.Remove(existingItem);

    }

    public void RemoveItemFromInventory(int i)
    {
        if (i < items.Count)
        {
            RemoveItemFromInventory(items[i]);
            Debug.Log("Drop");
        }
    }

}
