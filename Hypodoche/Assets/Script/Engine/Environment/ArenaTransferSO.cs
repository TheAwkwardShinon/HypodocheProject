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
        [SerializeField] private static GameObject[] _slotArray;
        [SerializeField] private static TrapItem[] _items;
        [SerializeField] private static GameObject _empty;
        #endregion

        #region  Getter and Setter
        public GameObject[] GetSlotArray()
        {
                return _slotArray;
        }
        public void SetSlot(int i, TrapItem item)
        {
            if (item != null)
                _slotArray[i] = item.GetPrefab();
            else
                _slotArray[i] = _empty;
            _items[i] = item;
        }

        public TrapItem GetItem(int i)
        {
            return _items[i];
        }
        #endregion 

        #region Methods 
        public void Reset()
        {
            Debug.Log("Reset ArenaSO");
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
