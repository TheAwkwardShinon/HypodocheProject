using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Hypodoche
{
    public class LuckyStar : MonoBehaviour,Traps
    {
        #region variables

        public float countdown = 50;
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
                countdown = countdown - 1;
                if (countdown == 0)
                {
                    countdown = 50;
                    timeIsRunning = false;
                    idle = false;
                }
            }
        }
        
        
        void OnTriggerEnter(Collider  col)
        {
            Debug.Log("Detected sth");
            if(col.gameObject.tag == "projectile" && !idle)
            {
                Destroy(col.gameObject);
                timeIsRunning = true;
                idle = true;
                Debug.Log("Detected");
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