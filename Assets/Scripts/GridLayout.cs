using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridLayout : LayoutGroup
{
    public enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns
    }

    public enum SortEnum
    {
        Rows,
        Columns
    }

    public enum SortVerticalyEnum
    {
        TopToBottom,
        BottomToTop
    }

    public enum SortHorizontalyEnum
    {
        LeftToRight,
        RightToLeft
    }

    public FitType fitType = FitType.Uniform;
    public int rows = 1;
    public int columns = 1;
    public Vector2 cellSize;
    public Vector2 spacing;

    public bool fitX;
    public bool fitY;
    public bool keepCellsSquare;

    public SortEnum fillFirst = SortEnum.Rows;                                 
    public SortVerticalyEnum sortVertically = SortVerticalyEnum.TopToBottom;    
    public SortHorizontalyEnum sortHorizontally = SortHorizontalyEnum.LeftToRight;   


    public override void CalculateLayoutInputVertical()
    {
  
    }

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        if (fitType == FitType.Uniform)
        {
            float squarRoot = Mathf.Sqrt(transform.childCount);
            rows = columns = Mathf.CeilToInt(squarRoot);
        }
        else if (fitType == FitType.FixedColumns || fitType == FitType.Width)
        {
            rows = Mathf.CeilToInt(transform.childCount / (float)columns);
        }
        else if (fitType == FitType.FixedRows || fitType == FitType.Height)
        {
            columns = Mathf.CeilToInt(transform.childCount / (float)rows);
        }

        float parentWidth = rectTransform.rect.width - padding.left - padding.right;
        float parentHeight = rectTransform.rect.height - padding.top - padding.bottom;

        float cellWidth = parentWidth / (float)columns - ((spacing.x / (float)columns) * (columns - 1));
        float cellHeight = parentHeight / (float)rows - ((spacing.y / (float)rows) * (rows - 1));

        cellSize.x = fitX ? cellWidth : cellSize.x;
        cellSize.y = fitY ? cellHeight : cellSize.y;

        if (keepCellsSquare)
        {
            cellSize.y = cellSize.x;
        }

        SortAndPositionChildren();
    }

    private void SortAndPositionChildren()
    {
        List<RectTransform> sortedChildren = new List<RectTransform>(rectChildren.Count);

        if (fillFirst == SortEnum.Rows)
        {

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int rowIndex = sortVertically == SortVerticalyEnum.TopToBottom ? row : rows - 1 - row;
                    int colIndex = sortHorizontally == SortHorizontalyEnum.LeftToRight ? col : columns - 1 - col;
                    int index = rowIndex * columns + colIndex;

                    if (index < rectChildren.Count)
                    {
                        sortedChildren.Add(rectChildren[index]);
                    }
                }
            }
        }

        else 
        {
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    int colIndex = sortHorizontally == SortHorizontalyEnum.LeftToRight ? col : columns - 1 - col;
                    int rowIndex = sortVertically == SortVerticalyEnum.TopToBottom ? row : rows - 1 - row;
                    int index = rowIndex + colIndex * rows;

                    if (index < rectChildren.Count)
                    {
                        sortedChildren.Add(rectChildren[index]);
                    }
                }
            }
        }

        for (int i = 0; i < sortedChildren.Count; i++)
        {
            int rowCount, columnCount;

            if (fillFirst == SortEnum.Rows)
            {
                rowCount = i / columns;
                columnCount = i % columns;
            }
            else
            {
                columnCount = i / rows;
                rowCount = i % rows;
            }

            var item = sortedChildren[i];

            var xPos = padding.left + (cellSize.x * columnCount) + (spacing.x * columnCount);
            var yPos = padding.top + (cellSize.y * rowCount) + (spacing.y * rowCount);

            if (childAlignment == TextAnchor.MiddleCenter || childAlignment == TextAnchor.MiddleLeft || childAlignment == TextAnchor.MiddleRight)
            {
                yPos = padding.top + (rectTransform.rect.height - padding.top - padding.bottom - (rows * cellSize.y + (rows - 1) * spacing.y)) / 2
                        + (cellSize.y + spacing.y) * rowCount;
            }
            else if (childAlignment == TextAnchor.LowerCenter || childAlignment == TextAnchor.LowerLeft || childAlignment == TextAnchor.LowerRight)
            {
                yPos = rectTransform.rect.height - padding.bottom - (rows * cellSize.y + (rows - 1) * spacing.y)
                        + (cellSize.y + spacing.y) * rowCount;
            }

            if (childAlignment == TextAnchor.MiddleCenter || childAlignment == TextAnchor.UpperCenter || childAlignment == TextAnchor.LowerCenter)
            {
                xPos = padding.left + (rectTransform.rect.width - padding.left - padding.right - (columns * cellSize.x + (columns - 1) * spacing.x)) / 2
                        + (cellSize.x + spacing.x) * columnCount;
            }
            else if (childAlignment == TextAnchor.MiddleRight || childAlignment == TextAnchor.UpperRight || childAlignment == TextAnchor.LowerRight)
            {
                xPos = rectTransform.rect.width - padding.right - (columns * cellSize.x + (columns - 1) * spacing.x)
                        + (cellSize.x + spacing.x) * columnCount;
            }

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }

    }

    public void GetXY(Vector3 worldPosition, out int x, out int y )
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize.x);
        y = Mathf.FloorToInt(-worldPosition.y / cellSize.y);
    }

    public Vector2 getLocalMousePosition(Vector2 localPoint)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, null, out localPoint);
        return localPoint;
    }

    public RectTransform getRectTransform()
    {
        return rectTransform;
    }
    public override void SetLayoutHorizontal()
    {

    }

    public override void SetLayoutVertical()
    {
        
    }
}
