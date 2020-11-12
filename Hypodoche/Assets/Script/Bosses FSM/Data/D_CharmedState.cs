using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Status Data/Charmed Data")]

    public class D_CharmedState : ScriptableObject
    {
        #region Variables
        public float minCharmedTime;
        public float maxCharmedTime;
        public LayerMask whatAttractsMe; //fire, water, wind, earth or just a trap effect;
        #endregion
    }
}
