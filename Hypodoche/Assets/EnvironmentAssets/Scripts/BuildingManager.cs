using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;
using UnityEngine.UI;
using Hypodoche;

namespace Hypodoche {
    public class BuildingManager : MonoBehaviour {
        
        #region Variables
        private TypeSelectUI _typeSelectUI;
        public Inventory _inventory;
        public GameObject _slots;
        public GameObject _emptyZone;
        private Grid _arenaGrid;
        private Grid _inventoryGrid;
        public GameObject _toolTip;
        public bool _isArenaOn;
        public int _xselected;
        public int _yselected;
        private bool _move;
        private Vector2 _mouseWorldPosition;
        private int _temp;
        
        #endregion

        #region Methods
        private void Start() {
            _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            _inventoryGrid = new Grid(-200, 125, 5, 5, 55, 0,false);
            DeselectInventory();
            _arenaGrid = new Grid(-200, 125, 5, 5, 55, -1,true);
            _typeSelectUI = GameObject.FindGameObjectWithTag("TypeSelectUI").GetComponent<TypeSelectUI>();
            _xselected = 2;
            _yselected = 2;
            _move = false;
            CloseToolTip();
            _temp = -1;
            //BuildArena();
        }

        private void Update() {
            //mouseWorldPosition = _arenaGrid.GetMouseWorldPosition();
            //int x;
            //int y;
            //_arenaGrid.GetXY(mouseWorldPosition,out x,out y);
            if (Input.GetMouseButtonDown(0) /*&& !EventSystem.current.IsPointerOverGameObject()*/) {
                _typeSelectUI.ScrollLeft();
            }

            if (Input.GetMouseButtonDown(1)) {
                _typeSelectUI.ScrollRight();
            }

            if (Input.GetKeyDown(KeyCode.I)) {
                if (_isArenaOn) {
                    SelectInventory();
                }
                else {
                    SelectArena();
                }
            }

            if (Input.GetKeyDown(KeyCode.Y)) {
                Build();
                Debug.Log("Build");
            }

            if (Input.GetKeyDown(KeyCode.U)) {
                Delete();
                Debug.Log("Delete");
            }

            if (Input.GetKeyDown(KeyCode.O) &&
                _arenaGrid._gridArray[_xselected,_yselected].GetComponent<Slot>()._itemId != -1) {
                if (_move) {
                    _move = false;
                    Debug.Log("No Move");
                }
                else {
                    _move = true;
                    Debug.Log("Move");
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && _xselected != 0) {
                MoveUp();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && _xselected != _arenaGrid._width - 1) {
                MoveDown();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && _yselected != _arenaGrid._height - 1) {
                MoveRight();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && _yselected != 0) {
                MoveLeft();
            }

        }
        
        public void SelectArena() {
            DeselectInventory();
            _arenaGrid.Activate();
            _typeSelectUI._grid.Activate();
            _isArenaOn = true;
        }

        public void DeselectArena() {
            _arenaGrid.Deactivate();
            _typeSelectUI._grid.Deactivate();
            _isArenaOn = false;
        }

        private void SelectInventory() {
            DeselectArena();
            _inventoryGrid.Activate();
        }

        public void DeselectInventory() {
            _inventoryGrid.Deactivate();
        }
        
        public GameObject CreateSlot(int x, int y, int itemId) {
            GameObject slot = (GameObject) Instantiate(_slots);
            slot.transform.SetParent(_inventory.gameObject.transform);
            slot.AddComponent<Slot>();
            slot.GetComponent<RectTransform>().localPosition = new Vector2(x, y);
            slot.GetComponent<Slot>()._itemId = itemId; // empty slot
            return slot;
        }

        public void ShowToolTip(Item item) {
            _toolTip.SetActive(true);
            _toolTip.transform.GetChild(0).GetComponent<Text>().text = item._title;
            _toolTip.transform.GetChild(1).GetComponent<Text>().text = item._description;
        }

        public void CloseToolTip() {
            _toolTip.SetActive(false);
        }

        private void Build() {
            _arenaGrid._gridArray[_xselected,_yselected].GetComponent<Slot>()._itemId = _typeSelectUI.GetActiveType();
            if (_move) {
                _move = false;
                Debug.Log("No Move");
            }
        }

        private void Delete() {
            _arenaGrid._gridArray[_xselected,_yselected].GetComponent<Slot>()._itemId = -1;
        }

        private void MoveUp() {
            _xselected--;
            if (_move) {
                int temp = -1;
                if (IsOccupied(_xselected, _yselected)) {
                    temp = _arenaGrid._gridArray[_xselected, _yselected].GetComponent<Slot>()._itemId;
                }
                _arenaGrid._gridArray[_xselected,_yselected].GetComponent<Slot>()._itemId =
                    _arenaGrid._gridArray[_xselected + 1,_yselected].GetComponent<Slot>()._itemId;
                _arenaGrid._gridArray[_xselected + 1,_yselected].GetComponent<Slot>()._itemId = _temp;
                _temp = temp;
            }
        }

        public void MoveDown() {
            _xselected++;
            if (_move) {
                int temp = -1;
                if (IsOccupied(_xselected, _yselected)) {
                    temp = _arenaGrid._gridArray[_xselected, _yselected].GetComponent<Slot>()._itemId;
                }
                _arenaGrid._gridArray[_xselected,_yselected].GetComponent<Slot>()._itemId =
                    _arenaGrid._gridArray[_xselected - 1,_yselected].GetComponent<Slot>()._itemId;
                _arenaGrid._gridArray[_xselected - 1,_yselected].GetComponent<Slot>()._itemId = _temp;
                _temp = temp;
            }
        }

        public void MoveRight() {
            _yselected++;
            if (_move) {
                int temp = -1;
                if (IsOccupied(_xselected, _yselected)) {
                    temp = _arenaGrid._gridArray[_xselected, _yselected].GetComponent<Slot>()._itemId;
                }
                _arenaGrid._gridArray[_xselected,_yselected].GetComponent<Slot>()._itemId =
                    _arenaGrid._gridArray[_xselected,_yselected - 1].GetComponent<Slot>()._itemId;
                _arenaGrid._gridArray[_xselected,_yselected - 1].GetComponent<Slot>()._itemId = _temp;
                _temp = temp;
            }
        }

        public void MoveLeft() {
            _yselected--;
            if (_move)
            {
                int temp = -1;
                if (IsOccupied(_xselected, _yselected)) {
                    temp = _arenaGrid._gridArray[_xselected, _yselected].GetComponent<Slot>()._itemId;
                }
                _arenaGrid._gridArray[_xselected, _yselected].GetComponent<Slot>()._itemId =
                    _arenaGrid._gridArray[_xselected, _yselected + 1].GetComponent<Slot>()._itemId;
                _arenaGrid._gridArray[_xselected, _yselected + 1].GetComponent<Slot>()._itemId = _temp;
                _temp = temp;
            }
        }

        private bool IsOccupied(int x,int y) {
            if (_arenaGrid._gridArray[x, y]) {
                return true;
            }
            return false;
        }

        public void LoadArena()
        {
            int x = -200;
            int y = 125;
            int cellSize = 55;
            Transform arena = transform.Find("Arena");
            for (int i = 0; i < _arenaGrid._gridArray.GetLength(0); i++) {
                for (int j = 0; j < _arenaGrid._gridArray.GetLength(1); j++)
                {   x = x + cellSize;
                    if (j == _arenaGrid._gridArray.GetLength(1) - 1)
                    {
                        x = -200;
                        y = y - cellSize;
                    }
                    GameObject obj;
                    int id = _arenaGrid._gridArray[i, j].GetComponent<Slot>()._itemId;
                    if (id != -1) {
                        obj= (GameObject) Instantiate(_inventory.GetItem(id)._prefab);
                        obj.transform.SetParent(arena);
                        obj.name = "Slot(" + i + "," + j + "):" + _inventory.GetItem(id)._title;
                    }
                    else {
                        obj = (GameObject) Instantiate(_emptyZone);
                        obj.transform.SetParent(arena);
                        obj.name = "Slot(" + i + "," + j + "):" + "empty";
                        Instantiate(_emptyZone);
                    }
                    obj.GetComponent<RectTransform>().localPosition = new Vector2(x, y);
                }
            }
        }

        #endregion
    }
}