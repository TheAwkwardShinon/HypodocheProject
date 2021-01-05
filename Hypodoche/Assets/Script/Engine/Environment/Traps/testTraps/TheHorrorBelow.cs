﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hypodoche
{
    public class TheHorrorBelow : MonoBehaviour,Traps
    {
        #region variables
        Effects myEffect;
        private Animator _animator;
        #endregion

        #region methods
        public TheHorrorBelow() {}

        public void Start(){
            StunData s = new StunData();
            s.isEmpty = true;
            DamageOverTimeData d = new DamageOverTimeData();
            d.isEmpty = true;
            SlowData sl = new SlowData();
            sl.isEmpty = true;
            DamageData dm = new DamageData();
            dm.isEmpty = true;
            FearData sc = new FearData();
            sc.isEmpty = true;
            SlowOverAreaData sla = new SlowOverAreaData();
            sla.isEmpty = true;
            DamageOverAreaData dma = new DamageOverAreaData();
            dma.isEmpty = false;
            dma.damage = 0.08f;
            EnhanceData en = new EnhanceData();
            en.isEmpty = true;
            myEffect = new Effects(sl, s, d, dm,sc,true,sla,dma,en);

            _animator = GetComponent<Animator>();
        }
        

        public void Update()
        {
            //if you want the trap to do something special
        }

        /*  public void OnTriggerEnter()
          {
  
          }*/

        public string SendDataTrap()
        {
            //Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }


        public void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("boss"))
            {
                _animator.SetBool("isActive", true);
                col.transform.root.GetComponent<Boss>().stepOnTrap(myEffect);
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if (col.gameObject.CompareTag("boss"))
            {
                _animator.SetBool("isActive", false);
                col.transform.root.GetComponent<Boss>().exitFromTrap();
            }
        }
        #endregion
    }
}
