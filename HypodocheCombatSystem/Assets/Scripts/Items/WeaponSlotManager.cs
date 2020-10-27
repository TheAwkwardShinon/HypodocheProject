using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class WeaponSlotManager : MonoBehaviour
    {
        #region Variables
        private WeaponHolderSlot _meleeSlot;
        private WeaponHolderSlot _rangedSlot;
        #endregion

        #region Methods
        private void Awake()
        {
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.GetIsMeleeSlot())
                    _meleeSlot = weaponSlot;
                else
                    _rangedSlot = weaponSlot;
            }
        }

        public void LoadWeaponOnSlot(Weapon weapon, bool onMelee)
        {
            if (onMelee)
                _meleeSlot.LoadWeaponSprite(weapon);
            else
                _rangedSlot.LoadWeaponSprite(weapon);
        }
        #endregion
    }
}
