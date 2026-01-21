using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName => name;

    public GameObject itemPrefab;

    public enum category
    {
        Sword,
        Shield,
        Helmet,
        Boots,
        Gem,
        Potion,
        Misc
    }

    public category itemCategory;
}
