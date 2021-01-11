using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Hypodoche
{
    public class PlayerStatus : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float _playerHealth;
        private float _playerStamina;
        [SerializeField] private float _staminaRegenRate = 15f;
        [SerializeField] private AnimatorHandler _animatorHandler;
        [SerializeField] private SceneDirector _sceneDirector;

        [SerializeField] private GameObject _GrabZone; 
        private float _staminaRegenDelay = 0.5f;
        public float _maxHealth = 120f;
        private float _maxStamina = 180f;
        private float _staminaRegenStartTime = 0f;
        private float _exhaustionPoint = 60f;
        private bool _isExhausted = false;

        #region status-variables
        private bool _isStunned = false;

        private float _stunTime;

        private float _startStunClock;

        private float _enhanceMultiplier = 0f;

        private float _permanentEnancheMultiplier = 0f;

        private float _layerChangedTime = 0f;

        private float _layerChangedClock;

        #endregion

        [SerializeField] private Image _stamina;
        [SerializeField] private Image _health;
        private Collider _collider;
        private List<Effects> _status = new List<Effects>();
        [SerializeField] private UI_AppearStatusIcon _icons;
        #endregion

        #region Getters and Setters
        public float GetPlayerHealth()
        {
            return _playerHealth;
        }

        public void SetPlayerHealth(float health)
        {
            _playerHealth = health;
            UpdateHealthUIValue();
        }

        public float GetMaxHealth()
        {
            return _maxHealth;
        }

               #region getter
        
        public Transform getGrabZone(){
            return _GrabZone.transform;
        }

        #region buff/debuff-getter
        public List<Effects> getDebuffList(){
            return _status;
        }

        public float  getStunTime(){
            return _stunTime;
        }

        public bool isStunned(){
            return _isStunned;
        }

        public float getStartStunClock(){
            return _startStunClock;
        }

        public float getEnancheMultiplier(){
            return _enhanceMultiplier;
        }

        public float getPermanentEnanche(){
            return _permanentEnancheMultiplier;
        }

        #endregion

        #region stats-getter

        public float getMaxStamina(){
            return _maxStamina;
        }

        public float getCurrentStamina(){
            return _playerStamina;
        }

        #endregion
 
        #endregion


        #region setter
        public void setStamina(float value){
            _playerStamina = _playerStamina + value >= _maxStamina ? _maxStamina : _playerStamina + value;
            UpdateStaminaUIValue();
        }

        public void setStun(float time, bool value){
            _isStunned = value;
            _stunTime = time;
            _startStunClock = Time.time;
        }

        public void AddPermanentEnanche(int value){
            _permanentEnancheMultiplier = value;
        }
        #endregion
        #endregion

        #region Methods
        private void Start()
        {
            _playerHealth = _maxHealth;
            _playerStamina = _maxStamina;
            _health.fillAmount = 1f;
            _stamina.fillAmount = 1f;
            _collider = GetComponent<Collider>();
        }
        private void Update()
        {
            checkActiveStatuses(); //addStatusEffects
            if(_isStunned){
                if(Time.time >= _startStunClock + _stunTime)
                    _isStunned = false;
            }
            if(_layerChangedTime > 0f){
                if(Time.time >= _layerChangedClock + _layerChangedTime)
                    changeLayerToPlayer();
            }          
            if (_playerStamina < _maxStamina && Time.time > _staminaRegenStartTime)
            {
                _playerStamina += _staminaRegenRate * Time.deltaTime;
                if (_playerStamina > _exhaustionPoint)
                    _isExhausted = false;
                if (_playerStamina > _maxStamina)
                    _playerStamina = _maxStamina;
            }

            UpdateStaminaUIValue();
            _animatorHandler.UpdateParameter("isStunned", _isStunned);
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
            _stamina.fillAmount = _playerStamina / _maxStamina;
        }

        #endregion

        #region Health

        public void TakeDamage(float damage)
        {
            _playerHealth -= damage;

            UpdateHealthUIValue();

            if (_playerHealth <= 0)
            {
                _animatorHandler.UpdateParameter("isDead", true);
                _health.color = Color.black;
                _stamina.color = Color.black;
                _collider.enabled = false;
                //gameObject.layer = default;
//                gameObject.tag = default;
                _animatorHandler.UpdateParameter("resetAnimator", true);
                Defeat();
            }
            _animatorHandler.ActivateTargetTrigger("isDamaged");
        }

        public void Defeat()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            StartCoroutine(PlayerDefeat());
        }

        IEnumerator PlayerDefeat()
        {
            yield return new WaitForSeconds(4);
            _sceneDirector.LoadSceneByName("DefeatScene");
        }

        private void UpdateHealthUIValue()
        {
            _health.fillAmount = _playerHealth / _maxHealth;
        }
        #endregion

        #region Statuses
        public void AddStatus(Effects effect)
        {
            _status.Add(effect);
        }

        public void RemoveStatus(Effects effect)
        {
            _status.Remove(effect);
        }

        public void checkActiveStatuses(){
            if(_status.Count > 0){
                foreach(Effects e in _status){
                    if(!e._stun.isEmpty){
                        _isStunned = true;
                        _stunTime = e._stun.time;
                        _startStunClock = Time.time;
                    }
                    if(!e._enhance.isEmpty){
                        _enhanceMultiplier = e._enhance.value;
                    }
                }
                _status.Clear();
            }
        }

        public void changeLayerToDefault(float time){
            gameObject.layer = LayerMask.NameToLayer("Default");
            _layerChangedTime = time;
            _layerChangedClock = Time.time;
        }

        public void changeLayerToPlayer(){
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

        public void RemoveEnanche(float value){
            _enhanceMultiplier = _enhanceMultiplier-value <= 0 ? 0f : _enhanceMultiplier-value;
        }

        #endregion
        
        #endregion
    }
}
