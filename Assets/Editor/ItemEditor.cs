using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemImageTaker))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ItemImageTaker imagetaker = (ItemImageTaker)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Take image"))
        {
            imagetaker.GenerateImage();
        }
    }
    
}
