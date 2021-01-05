using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class ShopManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private List<TrapSlot> _slots;
        [SerializeField] private TrapShop _trapShop;
        private SortedDictionary<string, TrapItem> _items;
        private int _x = 0;
        private int _y = 0;
        private TrapSlot _selectedSlot;
        private bool _activeInput = true;
        private bool _isPlayerLeftHanded = false;
        #endregion

        #region Getters and Setters
        public TrapItem GetSelectedItem()
        {
            if(_selectedSlot != null)
                return _selectedSlot.GetItem();
            else
                return null;
        }
        #endregion

        #region Methods
        private void Start()
        {
            _trapShop.Setup();
            _slots = new List<TrapSlot>(GetComponentsInChildren<TrapSlot>());
            _items = _trapShop.GetItems();
            DisplayShop();
            _selectedSlot = _slots[0];
            UpdateSelection(_x,_y,_x,_y);
        }

        private void Update(){
            if(_activeInput)
            {
                if(_isPlayerLeftHanded)
                    LeftHPlayerInput();
                else 
                    RightHPlayerInput();
                CommonInput();
            }
        }


        private void DisplayShop()
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

        #region Input
        private void LeftHPlayerInput()
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
                MoveSelectionUp();
            if(Input.GetKeyDown(KeyCode.DownArrow))
                MoveSelectionDown();
            if(Input.GetKeyDown(KeyCode.LeftArrow))
                MoveSelectionLeft();
            if(Input.GetKeyDown(KeyCode.RightArrow))
                MoveSelectionRight();
        }

        private void RightHPlayerInput()
        {
            if(Input.GetKeyDown(KeyCode.W))
                MoveSelectionUp();
            if(Input.GetKeyDown(KeyCode.S))
                MoveSelectionDown();
            if(Input.GetKeyDown(KeyCode.A))
                MoveSelectionLeft();
            if(Input.GetKeyDown(KeyCode.D))
                MoveSelectionRight();
        }

        private void CommonInput()
        {
            if(Input.GetMouseButtonDown(0))
            {
                //BUY
            }
            if(Input.GetMouseButtonDown(1))
            {
                //SELL?
            }
        }
        #endregion

        #region Move Selection
        private void MoveSelectionLeft()
        {
            UpdateSelection(_x, _y, _x, _y != 0 ? _y - 1 : 3);
        }
        private void MoveSelectionRight()
        {
            UpdateSelection(_x, _y, _x, _y != 3 ? _y + 1 : 0);
        }
        private void MoveSelectionDown()
        {
            UpdateSelection(_x, _y, _x != 2 ? _x + 1 : 0, _y);
        }
        private void MoveSelectionUp()
        {
            UpdateSelection(_x, _y, _x != 0 ? _x - 1 : 2, _y);
        }
        private void UpdateSelection(int previousX, int previousY, int x, int y)
        {
            _selectedSlot = _slots[previousX * 4 + previousY];
            _selectedSlot.GetComponent<Image>().color = Color.white;
            _selectedSlot = _slots[x * 4 + y];
            _selectedSlot.GetComponent<Image>().color = Color.red;
            _x = x;
            _y = y;
        }
        #endregion
        #endregion
    }
}
