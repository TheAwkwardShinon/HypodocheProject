using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    #region Required Components
    [RequireComponent(typeof(Image))]
    #endregion
    public class TrapSlot : MonoBehaviour
    {
        #region Variables
        private TrapItem _item;

        [SerializeField] private Image _itemIcon;
        [SerializeField] private Image _ownedAmountIcon;
        [SerializeField] private Text _ownedAmountText;
        private int _ownedAmount = -1;
        private bool _isShopSlot = false;
        #endregion

        #region Getter and Setter
        public void SetItem(TrapItem item)
        {
            _item = item;
            if (item != null){
                _itemIcon.enabled = true;
                _ownedAmountIcon.enabled = true;
                _ownedAmountText.enabled = true;
                _itemIcon.sprite = _item.GetItemSprite();
                _ownedAmount = _item.GetOwnedAmount();
                if(_isShopSlot){
                    _ownedAmountText.text = item.GetShopPrice().ToString();
                }
                else{
                    _ownedAmountText.text = _ownedAmount.ToString();
                }
            }
            else{
                _itemIcon.enabled = false;
                _ownedAmount = -1;
                _ownedAmountIcon.enabled = false;
                _ownedAmountText.enabled = false;
            }
        }
        public TrapItem GetItem()
        {
            return _item;
        }

        public void SetIsShopSlot(bool state)
        {
            _isShopSlot = state;
        }
        #endregion

        #region Methods
        private void Awake()
        {
            SetItem(null);
        }
        private void Update()
        {
            if(_ownedAmount == -1 && _ownedAmountIcon.enabled == true){
                _ownedAmountIcon.enabled = false;
                _ownedAmountText.enabled = false;
            }   
            else if(_ownedAmount != -1 && _ownedAmountIcon.enabled == false)
            {
                _ownedAmountIcon.enabled = true;
                _ownedAmountText.enabled = true;
                if(_isShopSlot)
                    _ownedAmountText.text = _item.GetShopPrice().ToString();
                else
                    _ownedAmountText.text = _ownedAmount.ToString();
            }
        }
        #endregion
    }
}
