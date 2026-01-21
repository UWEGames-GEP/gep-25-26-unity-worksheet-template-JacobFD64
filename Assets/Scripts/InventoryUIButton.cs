using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text text;

    private Item Item;

    [SerializeField] private ItemPreview preview;

    public PlayerInventory inventory;

    private Image image;

    private void Start()
    {
        inventory.RemoveItemEvent += HandleRemoveItem;

        image = GetComponent<Image>();
    }
    public void SetButton(Item item)
    {
        text.text = item.name;
        Item = item;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.lightSlateGray;

        if (preview.currentPreview == null)
        {
            preview.showItem(Item);
        }
        else if (preview.currentPreview.GetComponent<Item>().data == Item.data)
        {
            return;
        }
        else
        {
            preview.showItem(Item);
        }


    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void HandleRemoveItem()
    {
        preview.Clear();
        image.color = Color.white;
    }
}
