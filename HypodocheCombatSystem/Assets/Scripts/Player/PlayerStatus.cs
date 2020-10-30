using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class PlayerStatus : MonoBehaviour
    {
        #region Variables
        private float _playerHealth;
        private float _playerStamina;
        [SerializeField]private float _staminaRegenRate = 15f;
        private float _staminaRegenDelay = 0.5f;
        private float _maxHealth = 100f;
        private float _maxStamina = 100f;
        private float _staminaRegenStartTime = 0f;
        private float _exhaustionPoint = 30f;
        private bool _isExhausted = false;
        #endregion

        /*TODO Exchange with proper UI*/
        public Text _staminaText;

        #region Methods
        private void Start()
        {
            _playerHealth = _maxHealth;
            _playerStamina = _maxStamina;
        }

        private void Update()
        {
            if (_playerStamina < _maxStamina && Time.time > _staminaRegenStartTime)
            {
                _playerStamina += _staminaRegenRate * Time.deltaTime;
                if (_playerStamina > _exhaustionPoint)
                    _isExhausted = false;
                if (_playerStamina > _maxStamina)
                    _playerStamina = _maxStamina;
            }

            UpdateStaminaUIValue();
        }

        public bool HasStamina(float cost)
        {
            return (_playerStamina > cost && !_isExhausted);
        }

        public void SpendStamina(float cost)
        {
            _playerStamina -= cost;

            if (_playerStamina < 1f)
                _isExhausted = true;
            
            if (_playerStamina < _exhaustionPoint)
                _staminaRegenStartTime = Time.time + 3 * _staminaRegenDelay;
            else
                _staminaRegenStartTime = Time.time + _staminaRegenDelay;

        }

        public void UpdateStaminaUIValue()
        {
            _staminaText.text = ("Stamina: " + (int) _playerStamina);
            if (_playerStamina < _exhaustionPoint)
            {
                _staminaText.color = Color.red;
            }
            else if (_playerStamina < 50f)
                _staminaText.color = Color.yellow;
            else
            {
                _staminaText.color = Color.white;
            }
        }
        #endregion
    }
}
