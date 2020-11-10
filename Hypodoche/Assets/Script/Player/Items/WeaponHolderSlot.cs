using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class WeaponHolderSlot : MonoBehaviour
    {
        #region Variables
        [SerializeField] private bool _isMeleeSlot;
        [SerializeField] private Sprite _currentWeaponSprite;
        #endregion

        #region Getter and Setter
        public bool GetIsMeleeSlot()
        {
            return _isMeleeSlot;
        }
        #endregion

        #region Methods
        public void LoadWeaponSprite(Weapon weapon)
        {
            UnloadWeapon();

            if (weapon == null)
            {
                return;
            }

            _currentWeaponSprite = weapon.GetWeaponSprite();
        }

        public void UnloadWeapon()
        {
            if (_currentWeaponSprite != null)
                _currentWeaponSprite = null;
        }
        #endregion
    }
}
