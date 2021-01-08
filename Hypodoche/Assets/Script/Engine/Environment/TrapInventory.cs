using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu()]
    public class TrapInventory : ScriptableObject
    {
        #region Variables
        [SerializeField] private static List<TrapItem> _itemList;
        [SerializeField] private static int _playerCoins = 5;
        #endregion

        #region Getter and Setter
        public List<TrapItem> GetItemList()
        {
            return _itemList;
        }

        public void SetItemList(List<TrapItem> list)
        {
            _itemList = list;
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
        public void Reset()
        {
            Debug.Log("Reset Player Inventory");
            _itemList = new List<TrapItem>();
            _itemList.Clear();
            _playerCoins = 0;
        }

        public void Setup()
        {
            foreach (TrapItem entry in _itemList)
            {
                entry.SetOwnedCount(-1);
            }
        }

        public void Order()
        {
            List<TrapItem> temp = new List<TrapItem>();
            foreach(TrapItem item in _itemList)
            {
                int index = 0;
                while (index < temp.Count && String.Compare(item.GetItemName(), temp[index].GetItemName()) > 0)
                    index++;
                if(index == temp.Count)
                    temp.Add(item);
                else
                    temp.Insert(index, item);
            }
            _itemList = temp;
        }
        #endregion
    }
}
