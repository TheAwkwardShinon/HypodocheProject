using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu()]
    public class TrapShop : ScriptableObject
    {
        #region Variables
         private static List<TrapItem> _itemList;
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
            else{
                _itemList = new List<TrapItem>();
            }
            foreach(TrapItem item in shopList){
                _itemList.Add(item);
            }
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
