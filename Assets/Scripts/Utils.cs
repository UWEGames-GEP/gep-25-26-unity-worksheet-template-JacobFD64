using UnityEngine;

public static class Utils
{
    public static Vector3 getMouseGlobalPosition()
    {
        Vector3 mousepos = Input.mousePosition;

        mousepos.y = 10f;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousepos);

        return worldPos;
    }
    
}
