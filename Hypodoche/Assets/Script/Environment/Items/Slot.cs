using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hypodoche
{
    public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
    {

        #region Variables

        public Image _itemImage;
        public int _itemId;
        private BuildingManager _buildingManager;
        private Image _backgroundImage;
        private Sprite _selected;
        private Sprite _deselected;
        public int _x;
        public int _y;
        public bool _selectable;
        #endregion

        #region Methods

        void Start()
        {
            _buildingManager = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildingManager>();
            _itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
            _backgroundImage = gameObject.GetComponent<Image>();
            _selected = Resources.Load<Sprite>("Sprites/Selected");
            _deselected = _backgroundImage.sprite;
        }

        void Update()
        {
            if (_x == _buildingManager._xselected && _y == _buildingManager._yselected && _selectable) {
                _backgroundImage.sprite = _selected;
            }
            else {
                _backgroundImage.sprite = _deselected;
            }
            
            if (_buildingManager._inventory.GetItem(_itemId) != null)
            {
                _itemImage.enabled = true;
                _itemImage.sprite = _buildingManager._inventory.GetItem(_itemId)._icon;

            }
            else {
                _itemImage.enabled = false;
            }
        }

        public void OnPointerDown(PointerEventData data) {
            // work in progress....
        }

        public void OnPointerEnter(PointerEventData data)
        {

            if (_buildingManager._inventory.GetItem(_itemId) != null)
            {
                _buildingManager.ShowToolTip(_buildingManager._inventory.GetItem(_itemId));
            }
        }

        #endregion
    }
}