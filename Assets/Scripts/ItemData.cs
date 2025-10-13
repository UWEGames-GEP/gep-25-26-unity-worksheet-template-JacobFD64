using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName => name;

    public enum category
    {
        Sword,
        Shield,
        Helmet,
        Boots
    }

    public category itemCategory;
}
