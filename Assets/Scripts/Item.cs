using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;

    private MeshRenderer meshRenderer;

    private BoxCollider collider;
    
    private ParticleSystem particleSystem;

    public Item(ItemData data)
    {
        this.data = data;
    }

    public void Start()
    {
        collider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Pickup()
    {
        collider.enabled = false;
        meshRenderer.enabled = false;
        particleSystem.Play();
    }

    public void Drop()
    {
        collider.enabled = true;
        meshRenderer.enabled = true;
    }
}
    
   
    
