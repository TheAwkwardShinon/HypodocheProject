using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hypodoche
{
    public class TestTrap : MonoBehaviour,Traps
    {
        #region variables
        Effects myEffect;
        #endregion

        #region methods
        public TestTrap() {}

        public void Start()
        {
            StunData s = new StunData();
            s.isEmpty = false;
            s.time = 20;
            DamageOverTimeData d = new DamageOverTimeData();
            d.isEmpty = false;
            d.time = 20;
            d.damage = 3;
            SlowData sl = new SlowData();
            sl.isEmpty = true;
            DamageData dm = new DamageData();
            dm.isEmpty = true;
            myEffect = new Effects(sl, s, d, dm);
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
            Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }
        #endregion
    }
}