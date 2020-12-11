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
           
        }

        public void Awake()
        {
            StunData s = new StunData();
            s.isEmpty = false;
            s.time = 1.5f; // freezes on place for 4 sec
            DamageOverTimeData d = new DamageOverTimeData();
            d.isEmpty = true;
            SlowData sl = new SlowData();
            sl.isEmpty = true;
            DamageData dm = new DamageData();
            dm.isEmpty = true;
            FearData fear = new FearData();
            fear.isEmpty = true;
            SlowOverAreaData slowArea = new SlowOverAreaData();
            slowArea.isEmpty = true;
            DamageOverAreaData dmgArea = new DamageOverAreaData();
            dmgArea.isEmpty = true;
            EnhanceData enhance = new EnhanceData();
            enhance.isEmpty = true;
            myEffect = new Effects(sl, s, d, dm, fear, false, slowArea, dmgArea, enhance);
        }
     

        public void Update()
        {
            transform.position = transform.position + direction * speed * Time.deltaTime;
        }

        public string SendDataTrap()
        {
            Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }


        public void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("boss"))
            {
                col.transform.root.GetComponent<LiYan>().stepOnTrap(myEffect);
            }
        }

       

        #endregion
    }
        
}