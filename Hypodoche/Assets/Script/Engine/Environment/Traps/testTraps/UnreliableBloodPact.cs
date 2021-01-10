using System.Collections;
using System.Collections.Generic;
using Hypodoche;
using UnityEngine;


namespace Hypodoche{
    public class UnreliableBloodPact : MonoBehaviour,Traps
    {
        #region Variables

        [SerializeField] protected float _cooldown= 10f;
        private bool _isActive = true;

        private float _deadTime = 0f;

        private Animator _anim;

        [SerializeField] private float _lifesteal = 15f;

        [SerializeField] private int _minRandomEnancheMultiplier = 15;
        [SerializeField] private int _maxRandomEnancheMultiplier = 25;

        private int _enanche;



        #endregion

        #region methods


        public void Update()
        {
            if(Time.time > (_deadTime + _cooldown) && !_isActive)
            {
                _isActive = true;
                _anim.SetBool("isActive",true);

            }
        }

        void OnTriggerEnter(Collider col)
        {
            if(_isActive){
                if (col.gameObject.CompareTag("Player"))
                {
                    col.gameObject.GetComponent<PlayerStatus>().TakeDamage(_lifesteal);
                    _enanche = Random.Range(_minRandomEnancheMultiplier,_maxRandomEnancheMultiplier);
                    col.gameObject.GetComponent<PlayerStatus>().AddPermanentEnanche(_enanche);
                    _deadTime = Time.time;
                    _isActive = false;
                    _anim.SetBool("isActive",false);

                }
                else if (col.gameObject.CompareTag("boss"))
                {
                    col.transform.root.GetComponent<Enemy>().TakeDamage(_lifesteal);
                    _deadTime = Time.time;
                    _isActive = false;
                    _anim.SetBool("isActive",false);
                }
            }
        }

        public string SendDataTrap()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            _isActive = true;
            _anim = GetComponent<Animator>();
            _anim.SetBool("isActive",true);
        }


        #endregion
    }
}