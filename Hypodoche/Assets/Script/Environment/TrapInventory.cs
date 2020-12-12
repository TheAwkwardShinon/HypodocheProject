using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu()]
    public class TrapInventory : ScriptableObject
    {
        #region Variables
        [SerializeField] private List<TrapItem> _itemList;
        private SortedDictionary<string, TrapItem> _items;
        #endregion

        #region Getter and Setter
        public SortedDictionary<string, TrapItem> GetItems()
        {
            return _items;
        }

        public List<TrapItem> GetItemList()
        {
            return _itemList;
        }
        #endregion

        #region Methods
        public void Setup()
        {
            _items = new SortedDictionary<string, TrapItem>();
            foreach (TrapItem entry in _itemList)
            {
                _items.Add(entry.GetItemName(), entry);
                _items[entry.GetItemName()].SetOwnedCount(1);
            }
        }
        #endregion
    }
}
