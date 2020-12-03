using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class Bullet : MonoBehaviour,Traps
    {
        #region variables
        [SerializeField]public float speed;
        [SerializeField]public Vector3 direction;
        Effects myEffect;
        #endregion

        #region methods
        public Bullet() {}

        public void Start()
        {
            StunData s = new StunData();
            s.isEmpty = false;
            s.time = 4; // freezes on place for 4 sec
            DamageOverTimeData d = new DamageOverTimeData();
            d.isEmpty = true;
            SlowData sl = new SlowData();
            sl.isEmpty = true;
            DamageData dm = new DamageData();
            dm.isEmpty = true;
            //myEffect = new Effects(sl, s, d, dm);
        }

        void OnTriggerEnter(Collider col)
        {
            
        }

        public void Update()
        {
            transform.position = transform.position + direction * speed;
        }

        public string SendDataTrap()
        {
            Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }
            
        #endregion
    }
        
}