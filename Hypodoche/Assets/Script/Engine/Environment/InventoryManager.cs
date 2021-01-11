using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private TrapInventory _inventory;
        [SerializeField] GameObject  _inventoryGO;
        [SerializeField] private List<TrapSlot> _slots;
        [SerializeField] private Text _coinText;
        

        private void Awake()
        {
            _slots = new List<TrapSlot>(_inventoryGO.GetComponentsInChildren<TrapSlot>());
            _coinText.text = "Ethereal Lymph: " + _inventory.GetPlayerCoins().ToString()+" ml";
        }

        private void Start()
        {
            DisplayInventory();
        }

        #region Items
        public void AddItem(TrapItem trapItem)
        {
            int index = _inventory.GetItemList().IndexOf(trapItem);
            if(index != -1)
                _inventory.GetItemList()[index].IncreaseOwnedCount();
            else
            {
                trapItem.SetOwnedCount(1);
                _inventory.GetItemList().Add(trapItem);
            }
            _inventory.Order();
            DisplayInventory();
        }

        private void DisplayInventory()
        {
            int i = 0;
            foreach (TrapItem entry in _inventory.GetItemList())
            {
                if(i < _slots.Count){
                    _slots[i].SetItem(entry);
                    i++;
                }
            }
            _coinText.text = "Ethereal Lymph: " + _inventory.GetPlayerCoins().ToString()+" ml";
        }

        public void PlaceTrap(TrapItem trap)
        {
            int index = _inventory.GetItemList().IndexOf(trap);
            if(index != -1)
                _inventory.GetItemList()[index].DecreaseOwnedCount();
            DisplayInventory();
        }

        public void RetrieveTrap(TrapItem trap)
        {
            int index = _inventory.GetItemList().IndexOf(trap);
            if(index != -1)
                _inventory.GetItemList()[index].IncreaseOwnedCount();
            DisplayInventory();
        }

        public bool HasTrap(TrapItem trap)
        {
            int index = _inventory.GetItemList().IndexOf(trap);
            return index != -1 && _inventory.GetItemList()[index].GetOwnedAmount() > 0;
        }
        #endregion

        #region Coins
        public void AddCoins(int coins)
        {
            _inventory.SetPlayerCoins(_inventory.GetPlayerCoins() + coins);
        }

        public void SpendCoins(int coins)
        {
            _inventory.SetPlayerCoins(_inventory.GetPlayerCoins() - coins);
        }

        public bool CanAfford(TrapItem item)
        {
            return _inventory.GetPlayerCoins() >= item.GetShopPrice();
        }
        #endregion
    }
}
