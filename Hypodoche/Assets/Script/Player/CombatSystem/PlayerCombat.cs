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
        [SerializeField] private GameObject _leftShootingSpawnPoint;
        [SerializeField] private GameObject _rightShootingSpawnPoint;
        [SerializeField] private GameObject _leftMeleePoint;
        [SerializeField] private GameObject _rightMeleePoint;
        [SerializeField] private LayerMask _hitLayer;
        private float _attackRadius = 0.5f;
        private GameObject _activeMeleePoint;
        private float _nextAttackTime = 0f;
        private float _attackRate;
        private bool _isAiming = false;
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
            _activeMeleePoint = _rightMeleePoint;
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

            Collider[] hitObjects = Physics.OverlapSphere(_activeMeleePoint.transform.position, _attackRadius, _hitLayer);
            foreach (Collider hitObject in hitObjects)
            {
                Enemy enemy = hitObject.GetComponent<Enemy>();

                if (enemy != null)
                    enemy.TakeDamage(weapon.GetLightDamage());
            }

            _attackRate = weapon.GetLightAttackRate();

            _animatorHandler.ActivateTargetTrigger(weapon.GetLightAttacks()[Random.Range(0, weapon.GetLightAttacks().Length - 1)]);
        }

        //TODO Remove
        public void OnDrawGizmos(){
            if(_activeMeleePoint != null) Gizmos.DrawSphere(_activeMeleePoint.transform.position, _attackRadius);
        }

        public void HandleHeavyAttack(Weapon weapon)
        {
            Collider[] hitObjects = Physics.OverlapSphere(_activeMeleePoint.transform.position, _attackRadius, _hitLayer);
            foreach (Collider hitObject in hitObjects)
            {
                Enemy enemy = hitObject.GetComponent<Enemy>();

                if (enemy != null)
                    enemy.TakeDamage(weapon.GetHeavyDamage());
            }

            _attackRate = weapon.GetHeavyAttackRate();

            _animatorHandler.ActivateTargetTrigger(weapon.GetHeavyAttacks()[Random.Range(0, weapon.GetHeavyAttacks().Length - 1)]);
        }

        public void HandleShooting(Weapon weapon)
        {
            _shootingHandler.SetArrowStats(weapon);
            _shootingHandler.Shoot();
            _attackRate = weapon.GetLightAttackRate();
        }

        public void FlipShootingSpawnPoint(bool facesLeft)
        {
            if (facesLeft)
                _shootingHandler.SetActiveShootingPoint(_leftShootingSpawnPoint.transform);
            else
                _shootingHandler.SetActiveShootingPoint(_rightShootingSpawnPoint.transform);
        }

        public void FlipMeleePoint(bool facesLeft)
        {
            if (facesLeft)
                _activeMeleePoint = _leftMeleePoint;
            else
                _activeMeleePoint = _rightMeleePoint;
        }
        #endregion
    }
}