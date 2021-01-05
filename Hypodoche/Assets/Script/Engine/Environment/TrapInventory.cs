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
        [SerializeField] private int _playerCoins = 5;
        #endregion

        #region Getter and Setter
        public SortedDictionary<string, TrapItem> GetItems()
        {
            return _items;
        }

        public void SetItems(SortedDictionary<string, TrapItem> items)
        {
            _items = items;
            _itemList.Clear();
            foreach (KeyValuePair<string, TrapItem> entry in _items){
                _itemList.Add(entry.Value);
            }
        }

        public List<TrapItem> GetItemList()
        {
            return _itemList;
        }

        public void SetItemList(List<TrapItem> list)
        {
            Debug.Log("Set inventory to list containing " + list.Count);
            _itemList = list;
            Debug.Log("now Item List contains " + _itemList.Count + " elements");
        }

        public int GetPlayerCoins()
        {
            return _playerCoins;
        }

        public void SetPlayerCoins(int coins)
        {
            if (coins >= 99)
                coins = 99;
            _playerCoins = coins;

        }
        #endregion

        #region Methods
        public void Setup()
        {
            _items = new SortedDictionary<string, TrapItem>();
            foreach (TrapItem entry in _itemList)
            {
                _items.Add(entry.GetItemName(), entry);
                _items[entry.GetItemName()].SetOwnedCount(-1);
            }
        }
        #endregion
    }
}
