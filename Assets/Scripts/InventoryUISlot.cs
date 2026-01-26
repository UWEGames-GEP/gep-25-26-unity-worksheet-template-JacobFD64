using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Item Item;

    public Inventory inventory;

    private Image image;

    private void Start()
    {

        image = GetComponent<Image>();
    }
    public void SetButton(Item item)
    {
        Item = item;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
