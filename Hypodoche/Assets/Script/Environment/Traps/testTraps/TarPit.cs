﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hypodoche
{
    public class TarPit : MonoBehaviour,Traps
    {
        #region variables
        Effects myEffect;
        #endregion

        #region methods
        public TarPit() {}

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
            sla.isEmpty = false;
            sla.speed = 5;
            DamageOverAreaData dma = new DamageOverAreaData();
            dma.isEmpty = true;
            EnhanceData en = new EnhanceData();
            en.isEmpty = true;
            myEffect = new Effects(sl, s, d, dm,sc,true,sla,dma,en);
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

        #endregion
    }
}