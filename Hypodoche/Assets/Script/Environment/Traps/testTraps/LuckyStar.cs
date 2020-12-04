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
        private float _maxTime;
        public bool timeIsRunning;
        public bool idle;
        Effects myEffect;
        #endregion

        #region methods
        public LuckyStar() {}

        public void Start()
        {
            timeIsRunning = false;
            idle = false;
        }
        

        public void Update()
        {
            if (timeIsRunning)
            {
                CooldownTimer(Time.deltaTime);
            }
        }
        
        
        void OnTriggerEnter(Collider  col)
        {
            if(col.gameObject.CompareTag("Bomb") && !idle)
            {
                Destroy(col.gameObject);
                timeIsRunning = true;
                idle = true;
            }
        }

        public string SendDataTrap()
        {
            Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }

        private void CooldownTimer(float delta){
            countdown += delta;
            if(countdown % 60 > _maxTime){
                timeIsRunning = false;
                idle = false;
                countdown = 0f;
            }
        }
        #endregion
    }
}