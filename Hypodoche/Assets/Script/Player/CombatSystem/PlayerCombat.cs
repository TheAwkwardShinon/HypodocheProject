using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    #region Required Components
    [RequireComponent(typeof(ShootingHandler))]
    #endregion

    public class PlayerCombat : MonoBehaviour
    {
        #region Variables
        private AnimatorHandler _animatorHandler;
        private PlayerInventory _playerInventory;
        private ShootingHandler _shootingHandler;

        private PlayerStatus _playerStatus;
        [SerializeField] private GameObject _shootingSpawnPoint;
        [SerializeField] private GameObject _activeMeleePoint;
        [SerializeField] private LayerMask _hitLayer;

        [SerializeField] private LayerMask _secondHitLater;
        [SerializeField] private GameObject _impactPrefab;
        private float _attackRadius = 0.5f;
        private float _nextAttackTime = 0f;
        private float _attackRate;
        private bool _isAiming = false;
        private List<GameObject> alreadyHit = new List<GameObject>();
        #endregion

        #region Getter and Setter
        public void SetIsAiming(bool isAiming)
        {
            _isAiming = isAiming;
        }
        #endregion

        #region Methods
        private void Awake()
        {
            _animatorHandler = GetComponentInChildren<AnimatorHandler>();
            _playerInventory = GetComponent<PlayerInventory>();
            _shootingHandler = GetComponent<ShootingHandler>();
            _playerStatus = GetComponent<PlayerStatus>();
        }

        public float calculateDamage(float dmg){ //in percentuale
            float multiplier = _playerStatus.getEnancheMultiplier()+_playerStatus.getPermanentEnanche();
            if(multiplier == 0f) return dmg;
            else return dmg + ((dmg * multiplier)/100);
        }
 
        public void InvokeLightAttack()
        {
            if (Time.time > _nextAttackTime)
            {
                if (_isAiming)
                {
                    HandleShooting(_playerInventory.GetRangedWeapon());
                }
                else
                    HandleLightAttack(_playerInventory.GetMeleeWeapon());

                _nextAttackTime = Time.time + 1f / _attackRate;
            }
            Debug.Log("IsAiming: " + _isAiming);
            Debug.Log("Equipped Weapon is: " + _playerInventory.GetMeleeWeapon().name + " and its stats are: " +  _playerInventory.GetMeleeWeapon().GetLightDamage().ToString() + ", " + _playerInventory.GetMeleeWeapon().GetLightAttackRadius().ToString());
        }

        public void InvokeHeavyAttack()
        {
            if (Time.time > _nextAttackTime)
            {
                HandleHeavyAttack(_playerInventory.GetMeleeWeapon());
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
        }

        public void HandleLightAttack(Weapon weapon)
        {
            _attackRadius = weapon.GetLightAttackRadius();
            List<GameObject> alreadyHit = new List<GameObject>();
            
            Collider[] hitObjects = Physics.OverlapSphere(_activeMeleePoint.transform.position, _attackRadius, 
                _hitLayer);
            foreach (Collider hitObject in hitObjects)
            {
                GameObject hitParent = hitObject.transform.root.gameObject;
                Enemy enemy = hitParent.GetComponent<Enemy>();
                if (enemy != null && !alreadyHit.Contains(hitParent)){

                    enemy.TakeDamage(calculateDamage(weapon.GetLightDamage()));
                    alreadyHit.Add(hitParent);
                    Instantiate(_impactPrefab, hitObject.ClosestPointOnBounds(_activeMeleePoint.transform.position), Quaternion.identity);
                }
            }

            alreadyHit.Clear();

            _attackRate = weapon.GetLightAttackRate();

            _animatorHandler.ActivateTargetTrigger("LightAttack");
        }

        //TODO Remove
        public void OnDrawGizmos(){
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_activeMeleePoint.transform.position, _attackRadius);
        }

        public void HandleHeavyAttack(Weapon weapon)
        {
            alreadyHit = new List<GameObject>();

            Collider[] hitObjects = Physics.OverlapSphere(_activeMeleePoint.transform.position, _attackRadius, _hitLayer);
            foreach (Collider hitObject in hitObjects)
            {
                GameObject hitParent = hitObject.transform.root.gameObject;
                Enemy enemy = hitParent.GetComponent<Enemy>();

                if (enemy != null && !alreadyHit.Contains(hitParent)){
                    enemy.TakeDamage(calculateDamage(weapon.GetHeavyDamage()));
                    alreadyHit.Add(hitParent);
                }
            }

            alreadyHit.Clear();

            _animatorHandler.ActivateTargetTrigger("HeavyAttack");
        }

        public void HandleShooting(Weapon weapon)
        {
            Debug.Log("the dmg should be : "+ weapon.GetLightDamage()
            + " the multiplier is : "+_playerStatus.getEnancheMultiplier()
            +"%  so the dmg became : "+ calculateDamage(weapon.GetLightDamage()));
            _shootingHandler.SetArrowStats(calculateDamage(weapon.GetLightDamage()));
            _shootingHandler.Shoot();
            _attackRate = weapon.GetLightAttackRate();
        }
        #endregion
    }
}