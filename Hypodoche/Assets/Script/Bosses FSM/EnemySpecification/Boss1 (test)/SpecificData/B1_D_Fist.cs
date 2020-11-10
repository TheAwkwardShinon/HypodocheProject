using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(fileName = "newEntityData", menuName = "Data/State Data/Boss/TestBoss Fist")]

    public class B1_D_Fist : ScriptableObject
    {
        #region Variables
        public float fromRange = 0f;
        public float Torange;
        public float damage; //How can i check if the player is hit
        public float chargeTime; //???? yep or no?
        #endregion
    }
}