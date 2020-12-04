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
        [SerializeField] public GameObject[] _slotArray = new GameObject[25];
        #endregion

        #region  Getter and Setter
        public GameObject[] GetSlotArray()
        {
                return _slotArray;
        }
        public void SetSlot(int i, int j, GameObject prefab)
        {
            _slotArray[j + 5*i] = prefab;
        }
        #endregion 

        #region Methods 
        public string SendJson(){
            Debug.Log(JsonUtility.ToJson(_slotArray, true));
            return JsonUtility.ToJson(_slotArray, true);
        }
        #endregion
    }
}
