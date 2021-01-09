using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche{
    public class ArenaSlot : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TrapItem _item;
        [SerializeField] private Image _itemIcon;
        #endregion

        #region Methods 
        public void SetItem(TrapItem item)
        {
            _item = item;
            if(item != null)
            {
                _itemIcon.enabled = true;
                _itemIcon.sprite = item.GetItemSprite();
            }
            else
                _itemIcon.enabled = false;
        }

        public TrapItem GetItem()
        {
            return _item;
        }

        private void Awake()
        {
            //SetItem(null);
        }
        #endregion
    }
}
