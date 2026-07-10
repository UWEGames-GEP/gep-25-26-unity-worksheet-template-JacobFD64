using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public abstract class Inventory : MonoBehaviour
{
    private List<Item> items = new();

    public List<Item> Items => items;

    public Action<Item> RemoveItemEvent { get; internal set; }

    public virtual event Action <Item>PickUpItemEvent;

    private void Start()
    {

    }

    public virtual void AddItemToInventory(Item item)
    {
        var existingItem = item;

        items.Add(existingItem);

        PickUpItemEvent?.Invoke(item);

    }
    // This function spawns the item in front of the player as a base for removing an item
    public virtual void RemoveItemFromInventory(Item item)
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

}
