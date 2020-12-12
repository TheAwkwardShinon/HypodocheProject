using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Hypodoche
{
    public class LuckyStar : MonoBehaviour,Traps
    {
        #region variables
        public float countdown = 0f;
        private float _maxTime = 3f;
        public bool timeIsRunning;
        public bool idle;
        protected Collider _myCollider;
        Effects myEffect;
        #endregion

        #region methods
        public LuckyStar() {}

        public void Start()
        {
            _myCollider = gameObject.GetComponent<Collider>();
        }
        

        public void Update()
        {
            if (Time.time >= countdown && !_myCollider.enabled)
            {
                _myCollider.enabled = true; ;
            }
        }
        
        
        void OnTriggerEnter(Collider  col)
        {
            if(col.gameObject.CompareTag("Bomb"))
            {
                _myCollider.enabled = false;
                countdown = Time.time + _maxTime;
                
            }
        }

        public string SendDataTrap()
        {
            Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }

       
        #endregion
    }
}