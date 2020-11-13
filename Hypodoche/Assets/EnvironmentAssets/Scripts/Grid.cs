using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hypodoche;

namespace Hypodoche
{
    public class Grid
    {

        #region Variables

        public int _width;
        public int _height;
        public int _xstart;
        public int _ystart;
        public int _cellSize;
        public GameObject[,] _gridArray;

        #endregion

        #region Methods

        public Grid(int xstart, int ystart, int width, int height, int cellSize, int slotAmount,bool selectable)
        {
            _xstart = xstart;
            _ystart = ystart;
            _cellSize = cellSize;
            _height = height;
            _width = width;
            int x = xstart;
            int y = ystart;
            BuildingManager buildingManager =
                GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildingManager>();
            _gridArray = new GameObject[width, height];
            for (int i = 0; i < _gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < _gridArray.GetLength(1); j++)
                {
                    _gridArray[i, j] = new GameObject();
                    _gridArray[i, j] = buildingManager.CreateSlot(x, y, slotAmount);
                    _gridArray[i, j].GetComponent<Slot>()._x = i;
                    _gridArray[i, j].GetComponent<Slot>()._y= j;
                    _gridArray[i, j].GetComponent<Slot>()._selectable = selectable;
                    _gridArray[i, j].name = "Slot" + i + "," + j;
                    x = x + cellSize;
                    if (j == _gridArray.GetLength(1) - 1)
                    {
                        x = xstart;
                        y = y - cellSize;
                    }

                    if (slotAmount != -1)
                    {
                        // -1 is for Arena inizialization, i.e all empty slots, Inventory(TypeSelectUI),on the contrary, loads one by one all(the first 3) items in the item database .
                        slotAmount++;
                    }
                }
            }
        }

        public void Activate()
        {
            for (int i = 0; i < _gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < _gridArray.GetLength(1); j++)
                {
                    _gridArray[i, j].SetActive(true);
                }
            }
        }

        public void Deactivate()
        {
            for (int i = 0; i < _gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < _gridArray.GetLength(1); j++)
                {
                    _gridArray[i, j].SetActive(false);
                }
            }
        }

        public Vector2 GetWorldPosition(int x, int y)
        {
            return new Vector2(x, y) * _cellSize;
        }

        public Vector2 GetGridPosition(int x, int y)
        {
            return GetWorldPosition(x, y) + new Vector2(_cellSize, _cellSize) * .5f;
        }

        public void GetXY(Vector2 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt((worldPosition.x) / _cellSize);
            y = Mathf.FloorToInt((worldPosition.y) / _cellSize);
        }

        public Vector2 GetMouseWorldPosition()
        {
            Vector3 mouseWzPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                -Camera.main.transform.position.z);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseWzPos);
            return new Vector2(mousePos.x, mousePos.y);
        }

        #endregion
    }
}







// -------------- garbage
/*  //Initialize arena 
public Grid(int xstart, int ystart, int width, int height, int cellSize)
{
    this.xstart = xstart;
    this.ystart = ystart;
    this.cellSize = cellSize;

    int x = xstart;
    int y = ystart;
    BuildingManager buildingManager =
        GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildingManager>();
    gridArray = new GameObject[width, height];

    for (int i = 0; i < gridArray.GetLength(0); i++)
    {
        for (int j = 0; j < gridArray.GetLength(1); j++)
        {
            gridArray[i, j] = new GameObject();
            gridArray[i, j] = buildingManager.createSlot(x, y, -1);
            x = x + cellSize;
            if (j == gridArray.GetLength(1) - 1)
            {
                x = xstart;
                y = y - cellSize;
            }
        }
    }
}

    gridArray = new BuildingArea[width, height];
    
    for (int x = 0; x < gridArray.GetLength(0); x++) {
        for (int y = 0; y < gridArray.GetLength(1); y++) {
            gridArray[x,y]=new BuildingArea();
            Debug.DrawLine(GetWorldPosition(x,y),GetWorldPosition(x,y+1),Color.white,1000f);
            Debug.DrawLine(GetWorldPosition(x,y),GetWorldPosition(x+1,y),Color.white,1000f);
        }
        Debug.DrawLine(GetWorldPosition(0,height),GetWorldPosition(width,height),Color.white,1000f);
        Debug.DrawLine(GetWorldPosition(width,0),GetWorldPosition(width,height),Color.white,1000f);
    }


 
  ---------------------------
    public void SetValue(int x, int y, int value) {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            //Debug.Log(gridArray[x,y]);
            //debugTextArray[x, y].text = gridArray[x,y].ToString();
        }
        
    }
    
    public void SetValue(Vector2 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        //Debug.Log(x+","+y);
        SetValue(x, y, value);
    }

  
  
    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector2 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
    
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000) {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector2 localPosition, int fontSize,
        Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }   */
