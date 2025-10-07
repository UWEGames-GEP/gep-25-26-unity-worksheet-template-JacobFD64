using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();

    public GameManager gameManager;

    public void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItemToInventory("Generic Item");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveItemFromInventory("Generic Item");
        }
    }
    public void AddItemToInventory(string item)
    {
        items.Add(item);
    }

    public void RemoveItemFromInventory(string item)
    {
        items.Remove(item);
    }
}
