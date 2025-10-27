using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;

    public Item(ItemData data)
    {
        this.data = data;
    }

    public void Start()
    {
        data.collider = GetComponent<BoxCollider>();
        data.meshRenderer = GetComponent<MeshRenderer>();
        data.particleSystem = GetComponent<ParticleSystem>();
    }

    public void Pickup()
    {
        data.collider.enabled = false;
        data.meshRenderer.enabled = false;
        data.particleSystem.Play();
    }
}
    
   
    
