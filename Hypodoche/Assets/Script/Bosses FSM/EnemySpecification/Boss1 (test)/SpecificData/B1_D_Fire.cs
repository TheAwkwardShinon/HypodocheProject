using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(fileName = "newEntityData", menuName = "Data/State Data/Boss/TestBoss Fire")]

    public class B1_D_Fire : ScriptableObject
    {
        #region Variables
        public float angleRange = 180f;
        public float radius = 15f;
        public float fromRange = 6f;
        public float toRange;
        public float damage; //How can i check if the player is hit
        public float chargeTime; //???? yep or no?
        #endregion
    }
}