using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Status Data/Scared Data")]

    public class D_ScaredState : ScriptableObject
    {
        #region Variables
        public float minScaredTime;
        public float maxScaredTime;
        public LayerMask whatScaresMe; //fire, water, wind, earth or just a trap effect;
        #endregion
    }
}
