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
        [SerializeField] private GameObject _shootingSpawnPoint;
        [SerializeField] private GameObject _activeMeleePoint;
        [SerializeField] private LayerMask _hitLayer;
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
            List<GameObject> alreadyHit = new List<GameObject>();

            Collider[] hitObjects = Physics.OverlapSphere(_activeMeleePoint.transform.position, _attackRadius, _hitLayer);
            foreach (Collider hitObject in hitObjects)
            {
                GameObject hitParent = hitObject.transform.root.gameObject;
                Enemy enemy = hitParent.GetComponent<Enemy>();
                ///Enemy enemy  = hitObject.GetComponent<Enemy>();
                if (enemy != null && !alreadyHit.Contains(hitParent)){

                    enemy.TakeDamage(weapon.GetLightDamage());
                    //alreadyHit.Add(hitParent);
                }
            }

            alreadyHit.Clear();

            _attackRate = weapon.GetLightAttackRate();

            _animatorHandler.ActivateTargetTrigger("LightAttack");
        }

        //TODO Remove
        public void OnDrawGizmos(){
            if(_activeMeleePoint != null) Gizmos.DrawSphere(_activeMeleePoint.transform.position, _attackRadius);
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
                    enemy.TakeDamage(weapon.GetHeavyDamage());
                    alreadyHit.Add(hitParent);
                }
            }

            alreadyHit.Clear();

            _animatorHandler.ActivateTargetTrigger("HeavyAttack");
        }

        public void HandleShooting(Weapon weapon)
        {
            _shootingHandler.SetArrowStats(weapon);
            _shootingHandler.Shoot();
            _attackRate = weapon.GetLightAttackRate();
        }

        /*public void FlipShootingSpawnPoint(bool facesLeft)
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
        }*/
        #endregion
    }
}