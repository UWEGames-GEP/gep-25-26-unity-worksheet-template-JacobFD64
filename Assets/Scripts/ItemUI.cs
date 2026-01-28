using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public Image iconImage;

    public Text textImage;

    private GridLayout grid;

    private int area;

    private Item item;

    private void OnEnable()
    {
        
    }
    private void Start()
    {
        //item.data.icon.rect.Set(1,1,item.data.horizontalSlots,item.data.verticalSlots);
    }
    public void setItem(Item newItem)
    {
        item = newItem;

        iconImage.sprite = item.data.icon;
        //textImage.text = item.name;
    }

}
