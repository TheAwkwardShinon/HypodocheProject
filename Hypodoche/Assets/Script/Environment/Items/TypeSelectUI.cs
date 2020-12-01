using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hypodoche;

namespace Hypodoche
{
    public class TypeSelectUI : MonoBehaviour
    {

        #region Variables

        public GameObject _slots;
        private Inventory _inventory;
        public Grid _grid;

        #endregion

        #region Methods

        private void Start()
        {
            int slotAmount = 0;
            _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            _grid = new Grid(-145, -143, 1, 3, 55, 0,false);
        }

        public void ScrollRight()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_grid._gridArray[0, i].GetComponent<Slot>()._itemId == 0)
                {
                    _grid._gridArray[0, i].GetComponent<Slot>()._itemId = _inventory._items.Count - 1;
                }
                else
                {
                    _grid._gridArray[0, i].GetComponent<Slot>()._itemId =
                        _grid._gridArray[0, i].GetComponent<Slot>()._itemId - 1;
                }
            }
        }

        public void ScrollLeft()
        {

            for (int i = 0; i < 3; i++)
            {
                if (_grid._gridArray[0, i].GetComponent<Slot>()._itemId == _inventory._items.Count - 1)
                {
                    _grid._gridArray[0, i].GetComponent<Slot>()._itemId = 0;
                }
                else
                {
                    _grid._gridArray[0, i].GetComponent<Slot>()._itemId =
                        _grid._gridArray[0, i].GetComponent<Slot>()._itemId + 1;
                }
            }
        }

        public int GetActiveType()
        {
            return _grid._gridArray[0, 1].GetComponent<Slot>()._itemId;
        }

        #endregion
    }
}

