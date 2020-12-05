using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Hypodoche
{
    public class Enemy : MonoBehaviour
    {
        #region Variables
        private float _health;
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private Slider _healthSlider;
        #endregion

        #region Methods
        private void Start()
        {
            _maxHealth = gameObject.GetComponent<Boss>().getHealth();
            _health = _maxHealth;
            _healthSlider.value = _maxHealth / _health;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            UpdateHealthUI();
            if (_health <= 0){
                SceneManager.LoadScene(3);//Victory
                Destroy(gameObject);
            }
        }

        private void UpdateHealthUI()
        {
            _healthSlider.value = _health / _maxHealth;
        }
        #endregion
    }
}
