﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        public bool _isInventoryOn;
        public int _xselected;
        public int _yselected;
        private bool _move;
        private Vector2 _mouseWorldPosition;
        private int _temp;
        private int _maxtrap;
        public GameObject _arena;

        public GameObject _arenaBG;
        public GameObject _inventoryBG;

        public bool _buildingArena;
        
        
        [SerializeField] private ArenaTransferSO _arenaTransfer;
        #endregion

        #region Methods
        private void Awake()
        {
   
            _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            _arenaBG = GameObject.FindGameObjectWithTag("ArenaBG");
            _inventoryBG = GameObject.FindGameObjectWithTag("InventoryBG");
            _isArenaOn = false;
            _inventoryGrid = new Grid(-220, 220, 5, 5, 112, 0,false);
            _isArenaOn = true;
            _arenaGrid = new Grid(-97, 95, 5, 5, 50, -1,true); //-200,125
            _typeSelectUI = GameObject.FindGameObjectWithTag("TypeSelectUI").GetComponent<TypeSelectUI>();
            _xselected = 2;
            _yselected = 2;
            _maxtrap = 5;
            _move = false;
            _temp = -1;
            _isInventoryOn = false;
            //BuildArena();
        }

        private void Start()
        {
            DeselectInventory();
            SelectArena();
        }

        private void Update() {
            if(_isArenaOn)
            {
                if (Input.GetKeyDown(KeyCode.E)) /*&& !EventSystem.current.IsPointerOverGameObject()*/{
                    _typeSelectUI.ScrollLeft();
                }

                if (Input.GetKeyDown(KeyCode.Q)) {
                    _typeSelectUI.ScrollRight();
                }
                
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    if(_arenaGrid._gridArray[_xselected,_yselected].GetComponent<Slot>()._itemId == 
                        _typeSelectUI._grid._gridArray[0,1].GetComponent<Slot>()._itemId)
                    {
                        if (_move) {
                            _move = false;
                        }
                        else {
                            _move = true;
                        }
                    }
                    else if (CanBuild())
                    {
                        Build();
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    Delete();
                }

                if (Input.GetKeyDown(KeyCode.W) && _xselected != 0) {
                    MoveUp();
                }

                if (Input.GetKeyDown(KeyCode.S) && _xselected != _arenaGrid._width - 1) {
                    MoveDown();
                }

                if (Input.GetKeyDown(KeyCode.D) && _yselected != _arenaGrid._height - 1) {
                    MoveRight();
                }

                if (Input.GetKeyDown(KeyCode.A) && _yselected != 0) {
                    MoveLeft();
                }
            }

            if (Input.GetKeyDown(KeyCode.I)) {
                
                Change();
                //otherwise we are in oracle menu, not in building menu
            }

            if (Input.GetKeyDown(KeyCode.R))
                LoadArena();

            Item item;

            if(_isArenaOn){
                item = _inventory.GetItem(_typeSelectUI._grid._gridArray[0,1].GetComponent<Slot>()._itemId);
                ShowToolTip(item);
            }
        }


        private void Change()
        {
            if (_isArenaOn) {
                SelectInventory();
                return;
            }
                
            if (_isInventoryOn){
                SelectArena();
            }
        }
        
        public void SelectArena()
        {
            _arenaBG.SetActive(true);
            DeselectInventory();
            _arenaGrid.Activate();
            _typeSelectUI._grid.Activate();
            _isArenaOn = true;
            foreach (Transform child in _arenaBG.transform){
                child.gameObject.SetActive(true);
            }
        }

        public void DeselectArena()
        {
            _arenaBG.SetActive(false);
            _arenaGrid.Deactivate();
            _typeSelectUI._grid.Deactivate();
            foreach (Transform child in _arenaBG.transform){
                child.gameObject.SetActive(false);
            }
            _isArenaOn = false;
        }

        private void SelectInventory() {
            _inventoryBG.SetActive(true);
            DeselectArena();
            _inventoryGrid.Activate();
            _isInventoryOn = true;
            ShowToolTip(_inventory.GetItem(_inventoryGrid._gridArray[0,0].GetComponent<Slot>()._itemId));
        }

        public void DeselectInventory() {
            _inventoryBG.SetActive(false);
            _inventoryGrid.Deactivate();
            _isInventoryOn = false;
        }
        
        public GameObject CreateSlot(int x, int y, int itemId) {
            GameObject slot = (GameObject) Instantiate(_slots);
            if (_isArenaOn)
               slot.transform.SetParent(_arenaBG.gameObject.transform);
            else
                slot.transform.SetParent(_inventoryBG.gameObject.transform);
            slot.AddComponent<Slot>();
            slot.GetComponent<RectTransform>().localPosition = new Vector2(x, y);
            slot.GetComponent<Slot>()._itemId = itemId; // empty slot
            return slot;
        }

        public void ShowToolTip(Item item) {
            _toolTip.SetActive(true);
            _toolTip.transform.GetChild(0).GetComponent<Image>().sprite = item._icon;
            _toolTip.transform.GetChild(1).GetComponent<Text>().text = item._title;
            _toolTip.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = item._description;
            _toolTip.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = item._valueParam1;
            _toolTip.transform.GetChild(2).GetChild(3).GetComponent<Image>().sprite = item._spriteParam1;
            if (item._numParams == 2)
            {
                _toolTip.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);   
                _toolTip.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = item._valueParam2;
                _toolTip.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);   
                _toolTip.transform.GetChild(2).GetChild(2).GetComponent<Image>().sprite = item._spriteParam2; 
            }
            else
            {
                _toolTip.transform.GetChild(2).GetChild(1).gameObject.SetActive(false); 
                _toolTip.transform.GetChild(2).GetChild(2).gameObject.SetActive(false);  
            }
        }

        public void CloseToolTip() {
            _toolTip.SetActive(false);
        }

        private void Build() {
            _arenaGrid._gridArray[_xselected,_yselected].GetComponent<Slot>()._itemId = _typeSelectUI.GetActiveType();
            if (_move) {
                _move = false;
            }
        }

        private bool CanBuild()
        {
            int built = 0;
            for (int i = 0; i < _arenaGrid._gridArray.GetLength(0); i++) {
                for (int j = 0; j < _arenaGrid._gridArray.GetLength(1); j++)
                {
                    if (_arenaGrid._gridArray[i, j].GetComponent<Slot>()._itemId != -1)
                        built = built + 1;
                }
            }

            if ((built < _maxtrap) || ((built == _maxtrap) && (_move || IsOccupied(_xselected,_yselected))))
                return true;
            else
                return false;
            /*
               You can place a trap if :
               -number of traps is less than max number
               -number of traps is equal to max number and you are placing something which you are simply moving
               -number of traps is equal to max number and the place selected is already occupied so you can overwrite it without 
                exceeding the max number
            */
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
            if (_arenaGrid._gridArray[x, y].GetComponent<Slot>()._itemId!=-1) {
                return true;
            }
            return false;
        }

        public void LoadArena()
        {
            for (int i = 0; i < _arenaGrid._gridArray.GetLength(0); i++) {
                for (int j = 0; j < _arenaGrid._gridArray.GetLength(1); j++)
                {
                    int id = _arenaGrid._gridArray[i, j].GetComponent<Slot>()._itemId;
                    if (id != -1) {
                        _arenaTransfer.SetSlot(i,j, _inventory.GetItem(id)._prefab);
                    }
                    else {
                        _arenaTransfer.SetSlot(i,j,null);
                    }
                }
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        #endregion
    }
}