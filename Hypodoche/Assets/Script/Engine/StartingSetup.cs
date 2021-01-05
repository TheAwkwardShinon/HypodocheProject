using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class StartingSetup : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TrapInventory _playerInventory;
        [SerializeField] private TrapShop _shopInventory;
        [SerializeField] private int _startingPlayerCoins;
        #endregion

        #region Methods
        private void Awake()
        {
            _playerInventory.SetPlayerCoins(_startingPlayerCoins);
            _playerInventory.GetItemList().Clear();
            _playerInventory.Setup();
            _shopInventory.Setup();
        }
        #endregion
    }
}
