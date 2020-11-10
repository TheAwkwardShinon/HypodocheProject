using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Item : ScriptableObject
    {
        #region Variables
        [Header("Item Information")]
        public Sprite _itemIcon;
        public string _itemName;
        #endregion
    }
}
