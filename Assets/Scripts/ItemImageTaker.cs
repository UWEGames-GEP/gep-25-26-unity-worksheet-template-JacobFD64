using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ItemImageTaker : MonoBehaviour
{
    public GameObject item;

    private GameObject clone;
    public void GenerateImage()
    {
        int width = 1200;
        int height = 1200;
        string savePath = "Assets/Item Images";

        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        RenderTexture rt = new RenderTexture(width, height, 24);
        Camera cam = GetComponent<Camera>();
        cam.targetTexture = rt;

        Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGBA32, false);

        cam.Render();

        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        screenShot.Apply();

        cam.targetTexture = null;
        RenderTexture.active = null;
        DestroyImmediate(rt);

        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Path.Combine(savePath, item.GetComponent<Item>().data.itemName + " .png");
        File.WriteAllBytes(filename, bytes);

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
        Debug.Log($"Saved image to: {savePath}");
    }

    private void OnValidate()
    {
        EditorApplication.delayCall -= cloneItem;
        EditorApplication.delayCall += cloneItem;
    }
    private void cloneItem()
    {
        if (clone != null)
        {
            DestroyImmediate(clone);
            Debug.Log("clone destroyed");
        }
        if (item != null)
        {
            clone = Instantiate(item);
            clone.layer = LayerMask.NameToLayer("ItemPreview");
            clone.transform.position = this.transform.position;
            clone.transform.position += new Vector3(0f, 0f, 1f);
        }
    }
}
