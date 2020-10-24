using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newEntityData", menuName= "Data/Entity Data/Base Data")]

public class D_Entity : ScriptableObject
{
    public float wallCheckRange = 0.2f;
    public float waterCheckRange;
    public float windCheckRange;
    public float earthCheckRange;
    public float fireCheckRange;

    public LayerMask whatIsPerimeter
        ;
}
