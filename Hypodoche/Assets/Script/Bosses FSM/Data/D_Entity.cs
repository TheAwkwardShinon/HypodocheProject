using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

    public class D_Entity : ScriptableObject
    {
        #region Variables
        public float health = 100f;
        public float damageTakenOverTime = 0f;
        public float wallCheckRange = 0.2f;
        public float movementSpeed = 20f;
        public float speedWhenDetect = 30f;
        public float speedWhenSlowed = 5f;
        public float aggroRange;
        public LayerMask whatIsPerimeter;
        public LayerMask whatIsPlayer;
        public bool isSlowed = false;
        public bool gotDamageOverTime = false;
        public bool isStun = false;
        public float timeOfStun = 0f;
        public float timeOfSlow = 0f;
        public float timeOfDamage = 0f; //for damage over time;
        #endregion
    }
}