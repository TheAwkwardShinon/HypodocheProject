using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class BloodPool : MonoBehaviour
    {

        [SerializeField] private float _duration;
        [SerializeField] private float _healthBonus;
        [SerializeField] private float _playerDamage; //lo implementiamo???

        private Caputmallei _caputMallei;

        private float _startTime;
        
        void Start()
        {
            _startTime = Time.time;
        }

        void Update()
        {
            if(Time.time >= _startTime + _duration){
                _caputMallei.setBloodPoolCounter(_caputMallei.getBloodPoolCounter()-1);
                Destroy(gameObject);
            }
        }


        public void OnTriggerEnter(Collider col){
            if(col.CompareTag("boss")){
                _caputMallei.addHealth(_healthBonus);
                _caputMallei.setBloodPoolCounter(_caputMallei.getBloodPoolCounter()-1);
                Destroy(gameObject);
            }
            else if(col.CompareTag("Player")){
                col.gameObject.GetComponent<PlayerStatus>().TakeDamage(_playerDamage);
            }
        }

        public void setCaputMallei(Caputmallei caputMallei){
            _caputMallei = caputMallei;
        }

    }
}
