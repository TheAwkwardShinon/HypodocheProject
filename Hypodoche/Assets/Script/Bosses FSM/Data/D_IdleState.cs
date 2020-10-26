using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(fileName = "newIdleData", menuName = "Data/State Data/Idle State")]

    public class D_IdleState: ScriptableObject
    {
        #region Variables
        public float minIdleTime = 1f;
        public float maxIdleTime = 2f;
        #endregion
    }
}