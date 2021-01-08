using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Hypodoche{
    public class BuildManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private List<ArenaSlot> _slots;
        [SerializeField] private GameObject _builderGO;
        [SerializeField] private ArenaTransferSO _arenaTransferSO;
        [SerializeField] private TrapSelectionManager _trapSelectionManager;
        [SerializeField] private SceneDirector _sceneDirector;
        [SerializeField] private InventoryManager _inventory;
        private int _x = 0;
        private int _y = 0;
        private bool _isPlayerLeftHanded = false;
        private bool _isMovingTrap = false;
        private TrapItem _movingTrap = null;
        private TrapItem _trapBeingMovedOn = null;
        private ArenaSlot _selectedSlot;
        private bool _activeInput = true;
        #endregion

        #region Methods
        public void SetActiveInput(bool activeInput)
        {
            if(isActiveAndEnabled)
            {
                if (activeInput) StartCoroutine(activateInput());
                _activeInput = activeInput;
                if (activeInput) StopCoroutine(activateInput());
            }
        }

        IEnumerator activateInput()
        {
            yield return new WaitForSeconds(0.1f); 
        }

        private void Start()
        {
            _slots = new List<ArenaSlot>(_builderGO.GetComponentsInChildren<ArenaSlot>());
            LoadBuiltState();
            LoadArena();
            UpdateSelection(_x, _y, _x, _y);

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
                ManageTrap();
            }
            if(Input.GetMouseButtonDown(1))
            {
                DestroyTrap();
            }
        }
        #endregion

        #region Move Selection
        private void MoveSelectionLeft()
        {
            if(_isMovingTrap){
                _selectedSlot.SetItem(_trapBeingMovedOn);
            }
            UpdateSelection(_x, _y, _x, _y != 0 ? _y - 1 : 4);
            if(_isMovingTrap){
                _trapBeingMovedOn = _selectedSlot.GetItem();
                _selectedSlot.SetItem(_movingTrap);
            }
        }
        private void MoveSelectionRight()
        {
            if(_isMovingTrap){
                _selectedSlot.SetItem(_trapBeingMovedOn);
            }
            UpdateSelection(_x, _y, _x, _y != 4 ? _y + 1 : 0);
            if(_isMovingTrap){
                _trapBeingMovedOn = _selectedSlot.GetItem();
                _selectedSlot.SetItem(_movingTrap);
            }
        }
        private void MoveSelectionDown()
        {
            if(_isMovingTrap){
                _selectedSlot.SetItem(_trapBeingMovedOn);
            }
            UpdateSelection(_x, _y, _x != 4 ? _x + 1 : 0, _y);
            if(_isMovingTrap){
                _trapBeingMovedOn = _selectedSlot.GetItem();
                _selectedSlot.SetItem(_movingTrap);
            }
        }
        private void MoveSelectionUp()
        {
            if(_isMovingTrap){
                _selectedSlot.SetItem(_trapBeingMovedOn);
            }
            UpdateSelection(_x, _y, _x != 0 ? _x - 1 : 4, _y);
            if(_isMovingTrap){
                _trapBeingMovedOn = _selectedSlot.GetItem();
                _selectedSlot.SetItem(_movingTrap);
            }
        }
        private void UpdateSelection(int previousX, int previousY, int x, int y)
        {
            _selectedSlot = _slots[previousX * 5 + previousY];
            _selectedSlot.GetComponent<Image>().color = Color.white;
            _selectedSlot = _slots[x * 5 + y];
            _selectedSlot.GetComponent<Image>().color = Color.red;
            _x = x;
            _y = y;
        }
        #endregion

        #region Building
        private void ManageTrap()
        {
            if(_selectedSlot.GetItem() == _trapSelectionManager.GetSelectedItem() && !_isMovingTrap)
            {
                _isMovingTrap = true;
                _movingTrap = _selectedSlot.GetItem();
            }
            else if(DoesNotExceedLimits(_trapSelectionManager.GetSelectedItem()))
            {
                BuildTrap();
            }
            LoadArena();
        }

        private void BuildTrap()
        {
            if(_isMovingTrap){
                if(_trapBeingMovedOn != null){
                    _inventory.RetrieveTrap(_trapBeingMovedOn);
                }
                _isMovingTrap = false;
                _movingTrap = null;
                _trapBeingMovedOn = null;
            }
            else if (_selectedSlot.GetItem() == null) //Not Replacing an already existing trap
            {
                _inventory.PlaceTrap(_trapSelectionManager.GetSelectedItem());
            }
            else 
            {
                _inventory.PlaceTrap(_trapSelectionManager.GetSelectedItem());
                _inventory.RetrieveTrap(_selectedSlot.GetItem());
            }
            _selectedSlot.SetItem(_trapSelectionManager.GetSelectedItem());
        }

        private void DestroyTrap()
        {
            if(_selectedSlot.GetItem() != null)
            {
                _inventory.RetrieveTrap(_selectedSlot.GetItem());
                _selectedSlot.SetItem(null);
            }
            LoadArena();
        }

        private bool DoesNotExceedLimits(TrapItem item)
        {   
            return (_inventory.HasTrap(item) || _movingTrap == item);
        }
        #endregion

        public void LoadBuiltState()
        {
            int i;
            for (i = 0; i<25; i++){
                TrapItem currentItem = _arenaTransferSO.GetItem(i);
                _slots[i].SetItem(currentItem); 
            }
        }

        public void LoadArena()
        {
            int i;
            for(i=0; i<25;i++){
                TrapItem currentItem = _slots[i].GetItem();
                _arenaTransferSO.SetSlot(i,currentItem);
            }
        }
        #endregion
    }
}
