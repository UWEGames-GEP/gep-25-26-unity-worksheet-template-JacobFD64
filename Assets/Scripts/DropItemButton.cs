using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public PlayerInventoryUI inventoryUI;

    private CanvasGroup group;

    bool mouse_hovering;

    private void Start()
    {
        group = GetComponentInChildren<CanvasGroup>();

        InputReader.instance.StopMoveItemEvent += HandleStopMoveItem;
    }

    private void Update()
    {
        for (int i = 0; i < inventoryUI.itemUIs.Count; i++)
        {
            if(inventoryUI.itemUIs[i].holdingitem)
            {
                group.alpha = 1;

                break;
            }
            else if(inventoryUI.itemUIs.Count == 0)
            {
                group.alpha = 0;
            }
            else
            {
                group.alpha = 0;
            }
        }
    }

    private void HandleStopMoveItem()
    {
        for (int i = 0; i < inventoryUI.itemUIs.Count; i++)
        {
            if (mouse_hovering && inventoryUI.itemUIs[i].holdingitem)
            {
                inventoryUI.inventory.RemoveItem(inventoryUI.itemUIs[i].item, inventoryUI.itemUIs[i].currentSlotIndex);
                return;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_hovering = false;
    }
}
