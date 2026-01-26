using System.IO;
using UnityEditor;
using UnityEngine;

public class ItemImageTaker : MonoBehaviour
{
    public ItemData itemData;
    

   public void GenerateImage()
   {
        int width = 1024;
        int height = 512;
        string savePath = "Assets/ItemImages";

        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);
   }
}
