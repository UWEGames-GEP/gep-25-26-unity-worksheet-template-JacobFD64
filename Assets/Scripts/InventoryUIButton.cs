using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    public TMP_Text text;

    public void SetButton(Item item)
    {
        text.text = item.name;
    }
}
