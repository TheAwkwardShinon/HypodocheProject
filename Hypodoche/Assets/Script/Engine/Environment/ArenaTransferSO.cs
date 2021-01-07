using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hypodoche
{

    [CreateAssetMenu(menuName = "Data/ArenaSO")]
    public class ArenaTransferSO : ScriptableObject
    {
        #region Variables
        [Header("Prefab Array")]
        [SerializeField] private GameObject[] _slotArray;
        [SerializeField] private TrapItem[] _items;
        [SerializeField] private GameObject _empty;
        #endregion

        #region  Getter and Setter
        public GameObject[] GetSlotArray()
        {
                return _slotArray;
        }
        public void SetSlot(int i, int j, TrapItem item)
        {
            if (item != null)
                _slotArray[j + 5*i] = item.GetPrefab();
            else
                _slotArray[j + 5*i] = _empty;
            _items[j + 5*i] = item;

            //CheckConsistency();
        }

        public TrapItem GetItem(int i, int j)
        {
            return _items[j + 5*i];
        }
        #endregion 

        #region Methods 
        private void CheckConsistency()
        {
            int i;
            for(i = 0; i<25;i++){
                if(_items[i] == null)
                    _slotArray[i] = _empty;
                else
                    _slotArray[i] = _items[i].GetPrefab();
            }
        }
        public void Reset()
        {
            _slotArray = new GameObject[25];
            _items = new TrapItem[25];
            int i;
            for(i = 0; i<25; i++){
                _slotArray[i] = _empty;
                _items[i] = null;
            }
        }
        #endregion
    }
}
