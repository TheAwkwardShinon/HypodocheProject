using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    #region Required Components
    [RequireComponent(typeof(Animator))]
    #endregion

    public class AnimatorHandler : MonoBehaviour
    {
        #region Variables
        private Animator _animator;
        private int _vertical;
        private int _horizontal;
        #endregion

        #region Getter and Setter
        public Animator GetAnimator()
        {
            return _animator;
        }
        #endregion

        #region Methods
        public void Initialize()
        {
            _animator = GetComponent<Animator>();
            _vertical = Animator.StringToHash("Vertical");
            _horizontal = Animator.StringToHash("Horizontal");
        }

        public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isSprinting)
        {
            float v, h;
            #region Vertical
            v = verticalMovement;
            //TODO Aggiungere supporto sensibilità Joystick//
            #endregion
            #region Horizontal
            h = horizontalMovement;
            //TODO Aggiungere supporto sensibilità Joystick//
            #endregion

            if (isSprinting & h != 0){
                v = 2f;
                h = 2f;
            }

            _animator.SetFloat(_vertical, v, 0.1f, Time.deltaTime);
            _animator.SetFloat(_horizontal, h, 0.1f, Time.deltaTime);
        }

        public void UpdateParameter (string targetParameter, bool state)
        {
            _animator.SetBool(Animator.StringToHash(targetParameter), state);
        }
        
        public void ActivateTargetTrigger(string targetTrigger)
        { 
            _animator.SetTrigger(Animator.StringToHash(targetTrigger));
        }
        #endregion
    }
}
