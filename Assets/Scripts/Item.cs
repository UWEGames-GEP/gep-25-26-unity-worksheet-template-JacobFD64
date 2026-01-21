using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;

    private MeshRenderer meshRenderer;

    private BoxCollider collider;

    public Item(ItemData data)
    {
        this.data = data;
    }

    public void Start()
    {
        collider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Pickup()
    {
        collider.enabled = false;
        meshRenderer.enabled = false;
    }

    public void Drop()
    {
        collider.enabled = true;
        meshRenderer.enabled = true;
    }
}
    
   
    
