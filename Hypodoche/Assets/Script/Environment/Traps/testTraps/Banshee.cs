using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hypodoche
{
    public class Banshee : MonoBehaviour, Traps
    {
        #region variables

        Effects myEffect;
        [SerializeField] public float health;
        #endregion

        #region methods

        public Banshee()
        {
        }

        public void Start()
        {
            StunData s = new StunData();
            s.isEmpty = true;
            DamageOverTimeData d = new DamageOverTimeData();
            d.isEmpty = true;
            SlowData sl = new SlowData();
            sl.isEmpty = true;
            DamageData dm = new DamageData(); // deals dmg 
            dm.isEmpty = false;
            FearData sc = new FearData();
            sc.isEmpty = true;
            SlowOverAreaData sla = new SlowOverAreaData();
            sla.isEmpty = true;
            DamageOverAreaData dma = new DamageOverAreaData();
            dma.isEmpty = true;
            EnhanceData en = new EnhanceData();
            en.isEmpty = true;
            myEffect = new Effects(sl, s, d, dm, sc, false, sla, dma, en);
        }

        public void OnTriggerEnter()
        {
      
        }

        public void TakeDamage(float dmg)
        {
            health = health - dmg;
            float revenge = dmg / 2;
            myEffect._damage.damage = revenge;
            //send damage
            return ;
        }

        public void Update()
        {
            // if take damage

            if (health == 0)
            {
                Destroy(gameObject);

            }
        }

        public string SendDataTrap()
        {
            //Destroy(gameObject); should not be destroyed 
            return JsonUtility.ToJson(myEffect, true);
        }

        #endregion
    }
}
