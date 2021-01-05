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
        protected bool _active;
        protected float _revenge = 0;
        [SerializeField] private float _countdown;
        [SerializeField] private float _startTime;

        [SerializeField] private float _radius;
        #endregion


        #region methods


        public void Start()
        {
            _revenge = 0;
            /*StunData s = new StunData();
            s.isEmpty = true;
            DamageOverTimeData d = new DamageOverTimeData();
            d.isEmpty = true;
            SlowData sl = new SlowData();
            sl.isEmpty = true;
            DamageData dm = new DamageData(); 
            dm.isEmpty = false;
            dm.damage = 0;
            FearData sc = new FearData();
            sc.isEmpty = true;
            SlowOverAreaData sla = new SlowOverAreaData();
            sla.isEmpty = true;
            DamageOverAreaData dma = new DamageOverAreaData();
            dma.isEmpty = true;
            EnhanceData en = new EnhanceData();
            en.isEmpty = true;
            myEffect = new Effects(sl, s, d, dm, sc, false, sla, dma, en);*/
        }

        public void OnTriggerEnter(Collider col)
        {
            Debug.Log("plifffploff");
            if (Time.time >= _startTime + _countdown)
            {
                Debug.Log("due coccodrilli ed un orangotango");
                if (col.gameObject.CompareTag("Bomb"))
                {

                    _revenge += col.gameObject.GetComponent<RocketInterface>().getDamage()/4;
                    Debug.Log("REVENGE DMG = "+ _revenge);
                    col.gameObject.GetComponent<RocketInterface>().DestroyRocket();

                    //col.transform.root.GetComponent<LiYan>().stepOnTrap(myEffect);
                    //_active = false;
                    //_revenge = 0;
                    //myEffect.dm.damage = _revenge;
                }
        /*
                else if (col.gameObject.CompareTag("Player"))
                {
                    col.gameObject.GetComponent<PlayerStatus>().AddStatus(myEffect);
                    _active = false;
                    _revenge = 0;
                    myEffect.dm.damage = _revenge;
                }*/
            }
            
        }
/*
        public void TakeDamage(float dmg)
        {
            _revenge += dmg / 4;
            _active = true;
            myEffect.dm.damage = _revenge;
        }*/

        public void Update()
        {
           if(Time.time >= _startTime + _countdown){
                if(_revenge == 0) return;
                Collider[] col = Physics.OverlapSphere(gameObject.transform.position,_radius,LayerMask.GetMask("Player","Enemies"));
                if(col.Length > 0){
                    foreach (Collider target in col)
                    {
                        if(target.gameObject.CompareTag("boss"))
                                target.transform.root.GetComponent<Enemy>().TakeDamage(_revenge);
                        else if(target.gameObject.CompareTag("Player"))
                                target.GetComponent<PlayerStatus>().TakeDamage(_revenge);
                            _revenge = 0;
                            _startTime = Time.time;
                    }
                }
           }
        }

        
        public string SendDataTrap()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
