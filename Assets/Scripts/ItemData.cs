using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName => name;

    public MeshRenderer meshRenderer;

    public BoxCollider collider;

    public ParticleSystem particleSystem;

    public enum category
    {
        Sword,
        Shield,
        Helmet,
        Boots
    }

    public category itemCategory;
}
