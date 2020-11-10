using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    #region Required Components
    [RequireComponent(typeof(WeaponSlotManager))]
    #endregion

    public class PlayerInventory : MonoBehaviour
    {
        #region Variables
        private WeaponSlotManager _weaponSlotManager;
        [SerializeField] private Weapon _rangedWeapon;
        [SerializeField] private Weapon _meleeWeapon;
        #endregion
        
        #region Getter and Setter
        public Weapon GetRangedWeapon()
        {
            return _rangedWeapon;
        }

        public Weapon GetMeleeWeapon()
        {
            return _meleeWeapon;
        }
        #endregion

        #region Methods
        private void Awake()
        {
            _weaponSlotManager = GetComponent<WeaponSlotManager>();
        }

        private void Start()
        {
            _weaponSlotManager.LoadWeaponOnSlot(_meleeWeapon, true);
            _weaponSlotManager.LoadWeaponOnSlot(_rangedWeapon, false);
        }
        #endregion
    }
}

