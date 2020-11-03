using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingArea
{
    private BuildingTypeSO nameBuilding;
    private GameObject obj;


    public BuildingArea()
    {
        nameBuilding = null;
        obj = null;
    }

    public GameObject GetGameObject()
    {
        return obj;
    }

    public void SetGameObject(GameObject obj)
    {
        this.obj = obj;
    }

    public void SetNameBuilding(BuildingTypeSO nameBuilding)
    {
        this.nameBuilding = nameBuilding;
    }

    public BuildingTypeSO GetNameBuilding()
    {
        return nameBuilding;
    }

    public bool IsBuiltHere()
    {
        if (obj == null)
            return false;
        else
            return true;
    }

    public void FreeBuildingArea()
    {
        nameBuilding = null;
        obj = null;
    }

}
