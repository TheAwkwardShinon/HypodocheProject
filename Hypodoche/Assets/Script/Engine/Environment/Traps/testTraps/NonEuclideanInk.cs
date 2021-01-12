using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hypodoche
{
    public class NonEuclideanInk : MonoBehaviour,Traps
    {
        #region variables
        protected float _time = 2f;
        protected float _dmg = 0.4f;
        Effects myEffect;
        #endregion

        #region methods


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
            myEffect = new Effects(sl, s, d, dm,sc,false,sla,dma,en);
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

            Debug.Log("sono dentro il trigger");
            if (col.transform.root.gameObject.CompareTag("boss"))
            {
                Debug.Log("sono il boss e sono entrato");
                col.transform.root.GetComponent<Boss>().stepOnTrap(myEffect);
                Debug.Log("chiamato con insuccesso");
                if (_dmg > 0.05f)
                {
                    _dmg = _dmg / 2;
                    myEffect._damageOverTime.damage = _dmg;
                }
            }
            if (col.transform.root.gameObject.CompareTag("Player"))
            {
                if (_dmg < 0.4f)
                {
                    _dmg = _dmg + 0.05f;
                    myEffect._damageOverTime.damage = _dmg;
                }
            }
        }

        #endregion
    }
}