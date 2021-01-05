using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu()]
    public class TrapShop : ScriptableObject
    {
        #region Variables
        private SortedDictionary<string, TrapItem> _items;
        [SerializeField] private List<TrapItem> _itemList;
        #endregion

        #region Getters and Setters
        public SortedDictionary<string,TrapItem> GetItems()
        {
            return _items;
        }
        #endregion

        #region Methods
        public void Setup()
        {
            int index = 0;
            _items = new SortedDictionary<string, TrapItem>();
            foreach (TrapItem entry in _itemList)
            {
                _items.Add(entry.GetItemName(), entry);
                _items[entry.GetItemName()].SetOwnedCount(1);
                index++;
            }
        }
        #endregion  
    }
}
