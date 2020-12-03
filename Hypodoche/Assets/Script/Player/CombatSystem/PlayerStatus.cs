using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class PlayerStatus : MonoBehaviour
    {
        #region Variables
        public float _playerHealth;
        private float _playerStamina;
        [SerializeField] private float _staminaRegenRate = 15f;
        private float _staminaRegenDelay = 0.5f;
        public float _maxHealth = 100f;
        private float _maxStamina = 100f;
        private float _staminaRegenStartTime = 0f;
        private float _exhaustionPoint = 30f;
        private bool _isExhausted = false;
        #endregion

        [SerializeField] private Slider _staminaSlider;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Image _staminaColor;

        #region Methods
        
        private void Start()
        {
            _playerHealth = _maxHealth;
            _playerStamina = _maxStamina;
            _healthSlider.maxValue = _maxHealth;
            _staminaSlider.maxValue = _maxStamina;
            _staminaColor.color = Color.green;
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

        #region Stamina

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

        private void UpdateStaminaUIValue()
        {
            _staminaSlider.value = _playerStamina;
            if (_playerStamina < _exhaustionPoint)
            {
                _staminaColor.color = Color.red;
            }
            else if (_playerStamina < 50f)
                _staminaColor.color = Color.yellow;
            else
            {
                _staminaColor.color = Color.green;
            }
        }

        #endregion

        #region Health

        public void TakeDamage(float damage)
        {
            _playerHealth -= damage;

            UpdateHealthUIValue();

            if (_playerHealth <= 0)
            {
                //Die
            }
        }

        public void UpdateHealthUIValue()
        {
            _healthSlider.value = _playerHealth;
        }
        #endregion
        #endregion
    }
}
