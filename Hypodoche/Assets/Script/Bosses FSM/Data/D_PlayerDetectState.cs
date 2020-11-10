using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche {
    [CreateAssetMenu(fileName = "newEntityData", menuName = "Data/State Data/PlayerDetect State")]

    public class D_PlayerDetectState : ScriptableObject
    {
        #region Variables
        public float aggressivity; //from 0 to 100
        #endregion
    }
}
