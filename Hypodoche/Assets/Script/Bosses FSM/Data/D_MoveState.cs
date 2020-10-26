using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(fileName = "newMoveData", menuName = "Data/State Data/Move State")]

    public class D_MoveState : ScriptableObject
    {
        #region Variables
        public float movementSpeed = 3f;
        #endregion
    }
}

