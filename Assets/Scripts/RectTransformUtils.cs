using UnityEngine;

public static class RectTransformUtils
{
    public static bool IsOverlapping(RectTransform a, RectTransform b)
    {

        Rect rectA = GetWorldRect(a);
        Rect rectB = GetWorldRect(b);

        return rectA.Overlaps(rectB);
    }

    private static Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners); 

        float xMin = corners[0].x;
        float yMin = corners[0].y;
        float width = corners[2].x - xMin;
        float height = corners[2].y - yMin;

        return new Rect(xMin, yMin, width, height);
    }
}

