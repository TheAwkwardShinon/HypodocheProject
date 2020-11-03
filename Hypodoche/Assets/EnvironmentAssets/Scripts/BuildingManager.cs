using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;


public class BuildingManager : MonoBehaviour
{
    [SerializeField] private BuildingTypeSO activeBuildingType;
    private Grid grid;
    
    public enum Action
    {
        Nothing,
        Build,
        Delete,
        MoveFrom,
        MoveTo
    };

    public Action action;
    private Vector2 movingFrom;

    private void Start()
    {
        grid = new Grid(8, 2, 2.5f);
        action = Action.Nothing;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mouseWorldPosition = grid.GetMouseWorldPosition();
            int x;
            int y;
            grid.GetXY(mouseWorldPosition,out x,out y);
            if(x>=0 && y>=0 && x<grid.width && y<grid.height){
                switch (action)
                {
                    case Action.Nothing: break;
                    case Action.Build:
                        if (!grid.gridArray[x, y].IsBuiltHere())
                            Build(x, y);
                        break;
                    case Action.Delete:
                        if (grid.gridArray[x, y].IsBuiltHere())
                            Delete(x, y);
                        break;
                    case Action.MoveFrom:
                        if (grid.gridArray[x, y].IsBuiltHere())
                            MoveFrom(x, y);
                        break;
                    case Action.MoveTo:
                        if (!grid.gridArray[x, y].IsBuiltHere()) 
                            MoveTo(x, y);
                        break;
                }
            }
        }
    }

    public void SetCurrentAction(string action)
    {
        this.action =(Action)Enum.Parse(typeof(Action),action,false);
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSO)
    {
        activeBuildingType = buildingTypeSO;
    }

    public void Build(int x,int y)
    {

        GameObject obj = Instantiate(activeBuildingType.prefab,grid.GetGridPosition(x,y), Quaternion.identity).gameObject;
        grid.gridArray[x,y].SetGameObject(obj);
        grid.gridArray[x,y].SetNameBuilding(activeBuildingType);
    }

    public void Delete(int x, int y)
    {
        Destroy(grid.gridArray[x, y].GetGameObject());
        grid.gridArray[x,y].FreeBuildingArea();
    }

    public void MoveFrom(int x, int y)
    {
        movingFrom=grid.GetGridPosition(x,y);
        activeBuildingType = grid.gridArray[x, y].GetNameBuilding();
        action = Action.MoveTo;
    }

    public void MoveTo(int x, int y)
    {
        int xmoving, ymoving;
        grid.GetXY(movingFrom, out xmoving, out ymoving);
        Destroy(grid.gridArray[xmoving,ymoving].GetGameObject());
        grid.gridArray[xmoving,ymoving].FreeBuildingArea();
        GameObject obj = Instantiate(activeBuildingType.prefab,grid.GetGridPosition(x,y), Quaternion.identity).gameObject;
        grid.gridArray[x,y].SetGameObject(obj);
        grid.gridArray[x,y].SetNameBuilding(activeBuildingType);
        action = Action.Nothing;
    }

}
