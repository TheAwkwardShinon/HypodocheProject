using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Hypodoche{
    public class BuildManager : MonoBehaviour
    {
        [SerializeField] private List<ArenaSlot> _slots;
        [SerializeField] private GameObject _builderGO;
        [SerializeField] private ArenaTransferSO _arenaTransferSO;
        [SerializeField] private TrapSelectionManager _trapSelectionManager;
        private int _x = 0;
        private int _y = 0;
        private bool _isPlayerLeftHanded = false;
        private bool _isMovingTrap = false;
        private TrapItem _movingTrap = null;
        private TrapItem _trapBeingMovedOn = null;
        private ArenaSlot _selectedSlot;
        private int _builtCount = 0;
        private bool _activeInput = true;

        public void SetActiveInput(bool activeInput)
        {
            if (activeInput) StartCoroutine(activateInput());
            _activeInput = activeInput;
            if (activeInput) StopCoroutine(activateInput());
        }

        IEnumerator activateInput()
        {
            yield return new WaitForSeconds(0.1f); 
        }

        private void Awake()
        {
            _slots = new List<ArenaSlot>(_builderGO.GetComponentsInChildren<ArenaSlot>());
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
            if(Input.GetKeyDown(KeyCode.RightShift))
                LoadArena();
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
            if(Input.GetKeyDown(KeyCode.R))
                LoadArena();
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
            else if(DoesNotExceedLimits())
            {
                BuildTrap();
            }
        }

        private void BuildTrap()
        {
            if(_isMovingTrap){
                _isMovingTrap = false;
                _movingTrap = null;
                _trapBeingMovedOn = null;
            }
            else if (_selectedSlot.GetItem() == null) //Not Replacing an already existing trap
            {
                //Aggiorna inventory count
                _builtCount++;
            }
            _selectedSlot.SetItem(_trapSelectionManager.GetSelectedItem());
        }

        private void DestroyTrap()
        {
            if(_selectedSlot.GetItem() != null)
            {
                _selectedSlot.SetItem(null);
                _builtCount--;
            }
        }

        private bool DoesNotExceedLimits()
        {   Debug.Log(_builtCount);
            return _builtCount < 5 || (_builtCount == 5 && _selectedSlot.GetItem() != null); //Allow replacing
        }
        #endregion

        public void LoadArena()
        {
            int i = 0;
            int j = 0;
            foreach (ArenaSlot slot in _slots){
                TrapItem currentItem = slot.GetItem();
                if(currentItem != null)
                    _arenaTransferSO.SetSlot(i,j,currentItem.GetPrefab());
                j++;
                if(j == 5){
                    i++;
                    j=0;
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
