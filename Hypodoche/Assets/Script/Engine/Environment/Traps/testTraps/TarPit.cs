using System.Collections;
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
            sla.speed =1;
            DamageOverAreaData dma = new DamageOverAreaData();
            dma.isEmpty = true;
            EnhanceData en = new EnhanceData();
            en.isEmpty = false;
            en.value = 0.15f;
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


        public void OnTriggerEnter(Collider col)
        {
            Debug.Log("yep");
            //Debug.Log(col.transform.root.gameObject.tag);
            if (col.transform.root.gameObject.CompareTag("boss"))
            {
                Debug.Log("superYep");
                col.transform.root.GetComponent<Boss>().stepOnTrap(myEffect);
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if (col.transform.root.gameObject.CompareTag("boss"))
            {
                col.transform.root.GetComponent<Boss>().exitFromTrap();
            }
        }

        #endregion
    }
}
