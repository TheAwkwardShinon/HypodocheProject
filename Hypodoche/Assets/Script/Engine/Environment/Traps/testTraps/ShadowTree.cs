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
        [SerializeField]protected float _maxTime = 42f;

        [SerializeField] protected float _duration = 7f;

        private bool _active = true;

 

        #endregion

        #region methods

        public void Start()
        {
            _cooldown = 0f;
            _maxTime = 0f;
            _animator = GetComponent<Animator>();
            _animator.SetTrigger("isActive");

        }

        public void Update()
        {
            if (Time.time >= _maxTime + _cooldown){
                 _animator.ResetTrigger("inactive");
                _animator.SetTrigger("isActive");
            }

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (Time.time >= _maxTime + _cooldown){
                    col.gameObject.GetComponent<PlayerStatus>().changeLayerToDefault(_duration);
                    _animator.ResetTrigger("isActive");
                    _animator.SetTrigger("inactive");
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