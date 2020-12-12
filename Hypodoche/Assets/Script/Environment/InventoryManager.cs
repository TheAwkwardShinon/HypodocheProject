using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private TrapInventory _inventory;
        [SerializeField] GameObject  _inventoryGO;
        [SerializeField] private List<TrapSlot> _slots; 
        private SortedDictionary<string, TrapItem> _items = new SortedDictionary<string, TrapItem>();
        

        private void Awake()
        {
            _slots = new List<TrapSlot>(_inventoryGO.GetComponentsInChildren<TrapSlot>());
            _inventory.Setup();
            _items = _inventory.GetItems();
        }

        private void Start()
        {
            DisplayInventory();
        }

        public void AddItem(TrapItem trapItem)
        {
            TrapItem search = _items[trapItem.GetItemName()];
            if(search != null)
                search.IncreaseOwnedCount();
            else
                _items.Add(trapItem.GetItemName(), trapItem);
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
        }
    }
}
