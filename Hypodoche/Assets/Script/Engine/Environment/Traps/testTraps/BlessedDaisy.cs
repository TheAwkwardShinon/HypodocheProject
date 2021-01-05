using System.Collections;
using System.Collections.Generic;
using Hypodoche;
using UnityEngine;



namespace Hypodoche{

    public class BlessedDaisy : MonoBehaviour,Traps
    {
        #region Variables
        [SerializeField]protected float _deadTime = 14;
        [SerializeField]protected float _aliveTime = 7;

        [SerializeField] private float _multiplier = 40f;

        protected float _cooldown;

        protected bool _active;
        protected bool _poweredUp;

        protected Effects _myEffect;

        #endregion

        #region methods

        public void Start()
        {
            _active = false;
            _cooldown = Time.time + _deadTime;


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
            dma.isEmpty = true;
            EnhanceData en = new EnhanceData();
            en.isEmpty = false;
            en.value = _multiplier;
            _myEffect = new Effects(sl, s, d, dm, sc, true, sla, dma, en);
        }

        public void Update()
        {
            if (!_active && Time.time >= _cooldown) { 
                _active = true;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                _cooldown = Time.time + _aliveTime; 
            }
            if (_active && Time.time >= _cooldown)
            {
                _active = false;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                _cooldown = Time.time + _deadTime;
            }

        }
            
        void OnTriggerStay(Collider col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                if (_active && !_poweredUp)
                {
                    col.gameObject.GetComponent<PlayerStatus>().AddStatus(_myEffect);
                    _poweredUp = true;
                }
                if (!_active && _poweredUp)
                {
                    col.gameObject.GetComponent<PlayerStatus>().RemoveEnanche(_myEffect._enhance.value);
                    _poweredUp = false;
                }
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (_poweredUp)
                {
                    col.gameObject.GetComponent<PlayerStatus>().RemoveEnanche(_myEffect._enhance.value);
                    _poweredUp = false;
                }
            }
        }

        public string SendDataTrap()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
