using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class PlayerHubInputManager : MonoBehaviour
    {
        #region Constants
        private const float k_movementEpsilon = 0.05f;
        #endregion

        #region Variables
        private Vector3 _movement = Vector3.zero;
        [SerializeField] private AnimatorHandler _animatorHandler;
        [SerializeField] private PlayerHubMovement _playerMovement;
        private bool _isSprinting = false;
        private GameObject _interactingObject;
        [SerializeField] private bool _allowInput = true;
        #endregion

        #region Getters and Setters
        public void SetInteractingObject(GameObject obj)
        {
            _interactingObject = obj;
        }

        public void SetAllowInput(bool state)
        {
            _allowInput = state;
        }
        #endregion

        #region Methods
        private void Start()
        {
            _animatorHandler.Initialize();
        }
        private void Update()
        {
            if(_allowInput)
            {
                HandleMovementInput();
                HandleInteractionInput();
            }
        }

        private void HandleMovementInput()
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

            _isSprinting = Input.GetKey(KeyCode.Space);

            _animatorHandler.UpdateAnimatorValues(_movement.magnitude, _movement.magnitude, _isSprinting);
            _playerMovement.SetMovement(_movement);
            _playerMovement.SetIsSprinting(_isSprinting);
        }
        
        private void HandleInteractionInput()
        {
            if(Input.GetKeyDown(KeyCode.E) && _interactingObject != null)
            {
                BoardBehaviour bb = _interactingObject.GetComponent<BoardBehaviour>();
                if (bb != null){
                    bb.Interact();
                    return;
                }
                GateBehaviour gb = _interactingObject.GetComponent<GateBehaviour>();
                if (gb != null){
                    gb.Interact();
                    return;
                }
                OracleBehaviour ob = _interactingObject.GetComponent<OracleBehaviour>();
                if(ob != null){
                    ob.Interact();
                    return;
                }
            }
        }
        #endregion
    }
}
