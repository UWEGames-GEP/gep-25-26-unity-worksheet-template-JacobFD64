using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using System.Text.RegularExpressions;

public class ItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;

    public GridLayout grid;

    public int currentSlotIndex;

    public PlayerInventory inv;

    public Item item;

    public RectTransform rect;

    public bool hovering;

    public bool holdingitem;
    
    public bool toBeRemoved;

    private Vector3 offset;

    private Vector3 startingPosition;

    private Vector2 localPosition;

    public Action<int, ItemUI> MoveItemEvent { get; internal set; }

    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        InputReader.instance.MoveItemEvent += HandleMoveItem;
        InputReader.instance.StopMoveItemEvent += HandleStopMoveItem;
    }

    private void HandleRemoveItem(Item target_item)
    {
        if (target_item == item)
        {
            toBeRemoved = true;
            Destroy(gameObject);
            target_item = null;
        }
    }

    private void Update()
    {
        if (holdingitem)
        {
            transform.position = Input.mousePosition + offset;
        }
    }
    public void setItem(Item newItem)
    {
        item = newItem;

        iconImage.sprite = item.data.icon;

        float imageWidth = (grid.cellSize.x * item.data.horizontalSlots) + (grid.spacing.x * item.data.horizontalSlots) - grid.spacing.x;
        float imageHeight = (grid.cellSize.y * item.data.verticalSlots) + (grid.spacing.y * item.data.verticalSlots) - grid.spacing.y;

        rect.sizeDelta = new Vector2(imageWidth, imageHeight);

        rect.pivot = new Vector2(0, 1);

        inv.RemoveItemEvent += HandleRemoveItem;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    private void HandleMoveItem()
    {
        if (hovering)
        {
            holdingitem = true;
            iconImage.raycastTarget = false;
            transform.SetAsLastSibling();
            CalculateOffset();
            startingPosition = transform.position;
        }
    }
    private void HandleStopMoveItem()
    {
        if (holdingitem)
        {
            iconImage.raycastTarget = true;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(grid.getRectTransform(), transform.position, null, out localPosition);
            grid.GetXY(localPosition, out int x, out int y);

            if (x >= grid.columns || x < 0 || y >= grid.rows || y < 0)
            {
                transform.position = startingPosition;
                holdingitem = false;
                return;
            }
            int index = x + y * grid.columns;
            inv.RemoveItemFromSlot(item, currentSlotIndex);
            if (inv.checkSurroundingSlots(index, item, grid))
            {
                inv.AddItemToSlot(item, index);
                currentSlotIndex = index;
                MoveItemEvent?.Invoke(index, this);
            }
            else
            {
                inv.AddItemToSlot(item, currentSlotIndex);
                transform.position = startingPosition;
            }
        }

        holdingitem = false;
    }
    private void CalculateOffset()
    {
        offset = iconImage.transform.position - Input.mousePosition;
    }
    private void OnDestroy()
    {
        inv.RemoveItemEvent -= HandleRemoveItem;
    }
}
