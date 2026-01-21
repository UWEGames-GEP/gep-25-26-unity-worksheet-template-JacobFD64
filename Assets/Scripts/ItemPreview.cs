using UnityEngine;

public class ItemPreview : MonoBehaviour
{
    public Transform previewAnchor;

    public GameObject currentPreview;

    public Quaternion rotation;

    public void showItem(Item item)
    {
        rotation = Quaternion.identity;
        Clear();

        currentPreview = Instantiate(
            item.data.itemPrefab,
            previewAnchor.position,
            Quaternion.identity,
            previewAnchor);

        currentPreview.layer = LayerMask.NameToLayer("ItemPreview");
        SetLayerRecursively(currentPreview,currentPreview.layer);
    }

    private void Update()
    {
        if (currentPreview != null)
        {
            currentPreview.transform.Rotate(Vector3.up, 15f * Time.unscaledDeltaTime);
        }
    }

    public void Clear()
    {
        if(currentPreview != null)
        {
            Destroy(currentPreview);
        }
    }

    private void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach (Transform child in obj.transform)
        SetLayerRecursively(child.gameObject, layer);
    }
}
