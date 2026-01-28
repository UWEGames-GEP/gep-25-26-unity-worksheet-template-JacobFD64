using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;

    public Text textImage;

    public GridLayout grid;

    private int area;

    [SerializeField] private Item item;

    public RectTransform rect;

    bool hovering;

    bool holdingitem;

    private Vector3 offset;

    private void OnEnable()
    {
    }
    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        InputReader.instance.MoveItemEvent += HandleMoveItem;
        InputReader.instance.StopMoveItemEvent += HandleStopMoveItem;
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
            CalculateOffset();
        }
    }
    private void HandleStopMoveItem()
    {
        if (holdingitem)
        {
            grid.GetXY(Input.mousePosition, out int x, out int y);

            Debug.Log(x + " " + y);

            //transform.position = new Vector2(x, y);
        }

        

        holdingitem = false;
    }
    
    private void CalculateOffset()
    {
        offset = iconImage.transform.position - Input.mousePosition;
    }
}
