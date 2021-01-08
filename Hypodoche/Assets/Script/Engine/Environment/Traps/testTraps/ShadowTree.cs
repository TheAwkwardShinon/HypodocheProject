using System.Collections;
using System.Collections.Generic;
using Hypodoche;
using UnityEngine;

namespace Hypodoche{
public class ShadowTree : MonoBehaviour,Traps
    {
        #region Variables

        protected float _cooldown = 0f;
        protected float _maxTime = 42f;

        [SerializeField] protected float _duration = 7f;

        private bool _active = true;

 

        #endregion

        #region methods

        public void Start()
        {
            _cooldown = 0f;
            _maxTime = 0f;
        }

        public void Update()
        {

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (Time.time >= _maxTime + _cooldown){
                    col.gameObject.GetComponent<PlayerStatus>().changeLayerToDefault(_duration);
                    _cooldown = Time.time;
                    _maxTime = 42f;
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