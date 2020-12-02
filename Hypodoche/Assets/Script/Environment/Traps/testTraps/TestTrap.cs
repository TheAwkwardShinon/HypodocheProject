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
            s.isEmpty = true;
            s.time = 20;
            DamageOverTimeData d = new DamageOverTimeData();
            d.isEmpty = false;
            d.time = 20;
            d.damage = 3;
            SlowData sl = new SlowData();
            sl.isEmpty = true;
            DamageData dm = new DamageData();
            dm.isEmpty = true;
            FearData sc = new FearData();
            sc.isEmpty = false;
            sc.whatScareMe = LayerMask.GetMask("player");
            sc.timeOfFear = 15;

            myEffect = new Effects(sl, s, d, dm,sc);
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