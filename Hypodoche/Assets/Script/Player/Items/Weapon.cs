using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(menuName ="Weapon Item")]
    public class Weapon : ScriptableObject
    {
        #region Variables
        [SerializeField] private Sprite _weaponSprite;

        [Header("Animations")]
        [SerializeField] private string[] _lightAttacks;
        [SerializeField] private string[] _heavyAttacks;

        [Header("Stats")]
        [SerializeField] private float _lightDamage;
        [SerializeField] private float _heavyDamage;
        [SerializeField] private float _lightAttackRate;
        [SerializeField] private float _heavyAttackRate;
        [SerializeField] private float _lightAttackRadius;
        [SerializeField] private float _heavyAttackRadius;
        [SerializeField] private bool _isRanged;
        #endregion

        #region Getter and Setter
        public Sprite GetWeaponSprite()
        {
            return _weaponSprite;
        }

        #region Moveset
        public string[] GetLightAttacks()
        {
            return _lightAttacks;
        }

        public string[] GetHeavyAttacks()
        {
            return _heavyAttacks;
        }
        #endregion

        #region Damage
        public float GetLightDamage()
        {
            return _lightDamage;
        }

        public float GetHeavyDamage()
        {
            return _heavyDamage;
        }
        #endregion

        #region Attack Rate
        public float GetLightAttackRate()
        {
            return _lightAttackRate;
        }

        public float GetHeavyAttackRate()
        {
            return _heavyAttackRate;
        }
        #endregion

        #region Attack Radius
        public float GetLightAttackRadius()
        {
            return _lightAttackRadius;
        }

        public float GetHeavyAttackRadius()
        {
            return _heavyAttackRadius;
        }
        #endregion
        #endregion
    }
}
