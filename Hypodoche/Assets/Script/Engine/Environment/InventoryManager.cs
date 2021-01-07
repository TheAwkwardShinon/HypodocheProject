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
        private SortedDictionary<string, TrapItem> _items = new SortedDictionary<string, TrapItem>();
        

        private void Awake()
        {
            _slots = new List<TrapSlot>(_inventoryGO.GetComponentsInChildren<TrapSlot>());
            _items = _inventory.GetItems();
            _coinText.text = "Coins: " + _inventory.GetPlayerCoins().ToString();
        }

        private void Start()
        {
            DisplayInventory();
        }

        #region Items
        public void AddItem(TrapItem trapItem)
        {
            TrapItem search;
            search = _items.TryGetValue(trapItem.GetItemName(), out search) ? search : null;
            if(search != null)
                search.IncreaseOwnedCount();
            else
                _items.Add(trapItem.GetItemName(), trapItem);
            _inventory.SetItems(_items);
            DisplayInventory();
        }
        private void DisplayInventory()
        {
            int i = 0;
            foreach (KeyValuePair<string, TrapItem> entry in _items)
            {
                if(i < _slots.Count){
                    _slots[i].SetItem(entry.Value);
                    i++;
                }
            }
            _coinText.text = "Coins: " + _inventory.GetPlayerCoins().ToString();
        }

        public void PlaceTrap(TrapItem trap)
        {
            TrapItem search;
            search = _items.TryGetValue(trap.GetItemName(), out search) ? search : null;
            if(search != null)
                search.DecreaseOwnedCount();
            DisplayInventory();
        }

        public void RetrieveTrap(TrapItem trap)
        {
            TrapItem search;
            search = _items.TryGetValue(trap.GetItemName(), out search) ? search : null;
            if(search != null)
                search.IncreaseOwnedCount();
            DisplayInventory();
        }

        public bool HasTrap(TrapItem trap)
        {
            TrapItem search;
            search = _items.TryGetValue(trap.GetItemName(), out search) ? search : null;
            return search != null && search.GetOwnedAmount() > 0;
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
