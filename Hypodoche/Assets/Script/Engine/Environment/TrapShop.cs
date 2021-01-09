using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu()]
    public class TrapShop : ScriptableObject
    {
        #region Variables
        [SerializeField] private List<TrapItem> _itemList;
        #endregion

        #region Getters and Setters
        public List<TrapItem> GetItemList()
        {
            return _itemList;
        }
        #endregion

        #region Methods
        public void Reset(List<TrapItem> shopList)
        {
            Debug.Log("Reset Shop");
            if(_itemList != null)
                _itemList.Clear();
            _itemList = shopList;
        }
        public void Setup()
        {
            Debug.Log("Shop list contains " + _itemList.Count + " elements");
            foreach (TrapItem entry in _itemList)
            {
                entry.SetOwnedCount(1);
            }
        }
        #endregion  
    }
}
