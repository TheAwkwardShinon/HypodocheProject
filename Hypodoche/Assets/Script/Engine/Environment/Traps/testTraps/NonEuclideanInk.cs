using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hypodoche
{
    public class PurifyingWater : MonoBehaviour,Traps
    {
        #region variables
        protected float _time = 2f;
        protected float _dmg = 16f;
        Effects myEffect;
        #endregion

        #region methods
        public PurifyingWater() {}

        public void Start(){
            StunData s = new StunData();
            s.isEmpty = true;
            DamageOverTimeData d = new DamageOverTimeData();
            d.isEmpty = false;
            d.time = _time;
            d.damage = _dmg;
            SlowData sl = new SlowData();
            sl.isEmpty = true;
            DamageData dm = new DamageData();
            dm.isEmpty = true;
            FearData sc = new FearData();
            sc.isEmpty = true;
            SlowOverAreaData sla = new SlowOverAreaData();
            sla.isEmpty = true;
            DamageOverAreaData dma = new DamageOverAreaData();
            dma.isEmpty = true;
            EnhanceData en = new EnhanceData();
            en.isEmpty = true;
            myEffect = new Effects(sl, s, d, dm,sc,true,sla,dma,en);
        }
        

        public void Update()
        {

        }

        public string SendDataTrap()
        {
            //Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }


        public void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("boss"))
            {
                col.transform.root.GetComponent<Boss>().stepOnTrap(myEffect);
                if (_dmg > 1)
                {
                    _dmg = _dmg / 2;
                    myEffect._damageOverTime.damage = _dmg;
                }
            }
            if (col.gameObject.CompareTag("Player"))
            {
                if (_dmg < 16)
                {
                    _dmg = _dmg + 2;
                    myEffect._damageOverTime.damage = _dmg;
                }
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if (col.gameObject.CompareTag("boss"))
            {
                col.transform.root.GetComponent<Boss>().exitFromTrap();
            }
        }
        #endregion
    }
}