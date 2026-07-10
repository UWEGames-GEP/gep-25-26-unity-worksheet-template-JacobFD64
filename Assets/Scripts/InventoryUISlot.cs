using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    private Item Item;

    public Inventory inventory;

    private Image image;

    private RectTransform rect;

    private void Awake()
    {
    }
    private void Start()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        rect.pivot = new Vector2(0, 1);

    }
    public void SetButton(Item item)
    {
        Item = item;
    }
}
