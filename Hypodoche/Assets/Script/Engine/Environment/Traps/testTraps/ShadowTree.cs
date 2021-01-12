using System.Collections;
using System.Collections.Generic;
using Hypodoche;
using UnityEngine;

namespace Hypodoche{
public class ShadowTree : MonoBehaviour,Traps
    {
        #region Variables

        private Animator _animator;
        protected float _cooldown = 0f;
        [SerializeField]protected float _maxTime;

        [SerializeField] protected float _duration;

        private bool _isActive;

    
 

        #endregion

        #region methods

        public void Start()
        {
            _cooldown = Time.time;
            _animator = GetComponent<Animator>();
            _animator.SetBool("isActive",true);
            _animator.SetBool("inactive",false);
            _isActive = true;

        }

        public void Update()
        {
            if (!_isActive && Time.time >= _maxTime + _cooldown){
                // _animator.ResetTrigger("inactive");
                _isActive = true;
                _animator.SetBool("isActive",true);
                _animator.SetBool("inactive",false);

            }

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (_isActive){
                    col.gameObject.GetComponent<PlayerStatus>().changeLayerToDefault(_duration);
                    //_animator.ResetTrigger("isActive");
                    Debug.Log("TRIGGER SET");
                    _isActive = false;
                    _animator.SetBool("isActive",false);
                    _animator.SetBool("inactive",true);
                    _cooldown = Time.time;
                   // _maxTime = 42f;
                }
            }
        }

        public string SendDataTrap()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }

 
}