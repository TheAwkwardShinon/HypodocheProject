using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    #region Required Components
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerCombat))]
    [RequireComponent(typeof(PlayerStatus))]
    #endregion

    public class InputHandler : MonoBehaviour
    {
        #region Constants
        private const float k_movementEpsilon = 0.05f;
        #endregion

        #region Variables
        private Vector3 _movement;
        private bool _allowInput;
        private bool _isSprinting;
        private bool _isAiming;
        private int _resetAnimatorHash;
        private int _isAimingHash;
        private PlayerMovement _playerMovement;
        private PlayerStatus _playerStatus;
        private AnimatorHandler _animatorHandler;
        private PlayerCombat _playerCombat;
        private float _sprintInputTimer = 0f;
        private float _dashStaminaCost = 30f;
        private float _sprintStaminaCost = 5f;
        private float _heavyAttackStaminaCost = 10f;
        #endregion

        #region Getter and Setter
        //-EMPTY-//
        #endregion

        #region Methods
        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerCombat = GetComponent<PlayerCombat>();
            _playerStatus = GetComponent<PlayerStatus>();
            _animatorHandler = GetComponentInChildren<AnimatorHandler>();
            _animatorHandler.Initialize();
            _resetAnimatorHash = Animator.StringToHash("resetAnimator");
            _isAimingHash = Animator.StringToHash("isAiming");
        }

        private void Update()
        {
            _allowInput = !_animatorHandler.GetAnimator().GetBool(_resetAnimatorHash);

            if (_allowInput)
            {
                if (_playerMovement.GetIsDashing())
                    _playerMovement.SetIsDashing(false);
                if (_playerMovement.GetIsBackstepping())
                    _playerMovement.SetIsBackstepping(false);

                HandleMovementInput(Time.deltaTime);

                HandleMovementActions(Time.deltaTime);

                HandleAttacks(Time.deltaTime);

                HandleAiming(Time.deltaTime);

                _isSprinting = false;
            }
        }

        private void HandleMovementInput(float delta)
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.z = Input.GetAxisRaw("Vertical");
            _movement.y = 0;

            if (Mathf.Abs(_movement.x) < k_movementEpsilon)
                _movement.x = 0;
            if (Mathf.Abs(_movement.z) < k_movementEpsilon)
                _movement.z = 0;

            //We should handle things a bit differently if we want to have both walk and run
            _movement.Normalize();

            _animatorHandler.UpdateAnimatorValues(_movement.magnitude, 0, _isSprinting);
            _playerMovement.SetMovement(_movement);
        }

        private void HandleMovementActions(float delta)
        {
            #region Sprint
            if (Input.GetKey(KeyCode.Space) && _playerStatus.HasStamina(0f))
            {
                _sprintInputTimer += delta;
                _isSprinting = true;
            }
            #endregion

            #region Dash and Backstep
            else
            {
                if (_sprintInputTimer > 0 && _sprintInputTimer < 0.5f)
                {
                    _isSprinting = false;

                    if (Time.time > _playerMovement.GetNextDashTime() && _playerStatus.HasStamina(_dashStaminaCost))
                    {
                        if (_movement.magnitude > 0)
                        {
                            _playerMovement.SetIsDashing(true);
                            _animatorHandler.ActivateTargetTrigger("Dash");
                        }
                        else
                        {
                            _playerMovement.SetIsBackstepping(true);
                            _animatorHandler.ActivateTargetTrigger("Backstep");
                        }

                        _playerMovement.UpdateDashTime();
                        _playerStatus.SpendStamina(_dashStaminaCost);
                    }
                }

                _sprintInputTimer = 0;
            }
            #endregion

            if (_isSprinting)
                _playerStatus.SpendStamina(_dashStaminaCost * Time.deltaTime);

            _playerMovement.SetIsSprinting(_isSprinting);
        }

        private void HandleAttacks(float delta)
        {
            #region Light Attack
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _playerCombat.InvokeLightAttack();
                _movement = Vector3.zero;
                _playerMovement.SetMovement(_movement);
            }
            #endregion

            #region Heavy Attack
            else if (Input.GetKeyDown(KeyCode.Mouse1) && _playerStatus.HasStamina(_heavyAttackStaminaCost))
            {
                _playerCombat.InvokeHeavyAttack();
                _movement = Vector3.zero;
                _playerMovement.SetMovement(_movement);
                _playerStatus.SpendStamina(_heavyAttackStaminaCost);
            }
            #endregion
        }

        private void HandleAiming(float delta)
        {
            _isAiming = Input.GetKey(KeyCode.LeftShift);
            _animatorHandler.GetAnimator().SetBool(_isAimingHash, _isAiming);
            _playerCombat.SetIsAiming(_isAiming);

            if (_isAiming)
            {
                _playerMovement.FollowMousePointer();
                _movement = Vector3.zero;
                _playerMovement.SetMovement(_movement);
            }
        }
        #endregion
    }
}
