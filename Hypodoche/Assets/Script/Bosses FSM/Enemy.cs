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
        //[SerializeField] private Slider _healthSlider;
        [SerializeField] private Image _healthFill;
        #endregion

        #region Getters and Setters
        public void SetFill(Image fill)
        {
            _healthFill = fill;
        }

        public void setHealth(){
            _health = gameObject.GetComponent<Boss>().getHealth();
            UpdateHealthUI();
        }
        #endregion

        #region Methods
        private void Start()
        {
            _maxHealth = gameObject.GetComponent<Boss>() == null ? gameObject.GetComponent<Minion>().getHealth() : gameObject.GetComponent<Boss>().getHealth();
            Debug.Log("Max Health = "+ _maxHealth);
            _health = _maxHealth;
            _healthFill.fillAmount = 1f;
        }

        public void TakeDamage(float damage)
        {
            
            if(gameObject.GetComponent<Boss>()!= null){
                Debug.Log("took damage -->name: "+gameObject.name);
                _health -= damage;
                gameObject.GetComponent<Boss>().setHealth(damage);
            }
            else {
                if(!gameObject.GetComponent<Minion>().IsIneluttable()){
                    _health -= damage;
                    gameObject.GetComponent<Minion>().setHealth(damage);
                }
            }
            UpdateHealthUI();
            /*if (_health <= 0){
                SceneManager.LoadScene(3);//Victory
                Destroy(gameObject);
            }*/
        }

        private void UpdateHealthUI()
        {
            _healthFill.fillAmount = _health / _maxHealth;
            Debug.Log("Updated health ui + healt : "+_health+" _health.fillAmount : "+_healthFill.fillAmount);

        }
        #endregion


        #region getter
        public float getMaxHealth(){
            return _maxHealth;
        }
        #endregion
    }
}
