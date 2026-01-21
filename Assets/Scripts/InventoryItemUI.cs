using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;

    public ItemPreview preview;

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {

    }
}
