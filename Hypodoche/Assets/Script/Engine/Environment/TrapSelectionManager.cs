using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class TrapSelectionManager : MonoBehaviour
    {
        [SerializeField] TrapItem _selectedItem = null;
        [SerializeField] ArenaSlot _centralSlot;
        [SerializeField] ArenaSlot _leftSlot;
        [SerializeField] ArenaSlot _rightSlot;
        [SerializeField] TrapInventory _inventory;
        private List<TrapItem> _itemList;
        private int _currentIndex = 0;
        private bool _isPlayerLeftHanded = false;
        private bool _activeInput = true;

        public void SetActiveInput(bool activeInput)
        {
            _activeInput = activeInput;
        }


        public TrapItem GetSelectedItem()
        {
            return _selectedItem;
        }

        private void Start()
        {
            _itemList = _inventory.GetItemList();
        }

        private void Update()
        {
            _itemList = _inventory.GetItemList();
            UpdateView();
            if(_activeInput)
                ChangeSelection();
        }

        private void UpdateView()
        {
            if(_itemList.Count > 0){
                _leftSlot.SetItem(_itemList[_currentIndex]);
                if(_itemList.Count == 1){
                    _centralSlot.SetItem(_itemList[_currentIndex]);
                    _rightSlot.SetItem(_itemList[_currentIndex]);
                }
                else if(_itemList.Count == 2){
                    _centralSlot.SetItem(_itemList[_currentIndex]);
                    _rightSlot.SetItem(_itemList[(_currentIndex + 1) % _itemList.Count]);
                }
                else {
                    _centralSlot.SetItem(_itemList[(_currentIndex + 1) % _itemList.Count]);
                    _rightSlot.SetItem(_itemList[(_currentIndex + 2) % _itemList.Count]);
                }

                _selectedItem = _centralSlot.GetItem();
            }
        }

        private void ChangeSelection()
        {
            if(_isPlayerLeftHanded)
                LeftHPlayerInput();
            else
                RightHPlayerInput();
        }

        private void LeftHPlayerInput()
        {
            if(Input.GetKeyDown(KeyCode.RightControl))
                ScrollLeft();
            if(Input.GetKeyDown(KeyCode.Keypad0))
                ScrollRight();            
        }

        private void RightHPlayerInput()
        {
            if(Input.GetKeyDown(KeyCode.Q))
                ScrollLeft();
            if(Input.GetKeyDown(KeyCode.E))
                ScrollRight();
        }

        private void ScrollLeft()
        {
            _currentIndex--;
            if(_currentIndex < 0)
                _currentIndex = _itemList.Count - 1;

            /*
            _rightSlot.SetItem(_centralSlot.GetItem());
            _centralSlot.SetItem(_leftSlot.GetItem());
            _currentIndex--;
            if(_currentIndex < 0)
                _currentIndex = _itemList.Count - 1;
            _leftSlot.SetItem(_itemList[_currentIndex]);
            _selectedItem = _centralSlot.GetItem();*/
        }

        private void ScrollRight()
        {
            _currentIndex++;
            _currentIndex %= _itemList.Count;

            /*
            _leftSlot.SetItem(_centralSlot.GetItem());
            _centralSlot.SetItem(_rightSlot.GetItem());
            _currentIndex++;
            if(_currentIndex >= _itemList.Count)
                _currentIndex = 0;
            if(_currentIndex + 2 >= _itemList.Count)
                _rightSlot.SetItem(_itemList[_currentIndex + 2 - _itemList.Count]);
            else
                _rightSlot.SetItem(_itemList[_currentIndex + 2]); 

            _selectedItem = _centralSlot.GetItem();*/
        }
    }
}
