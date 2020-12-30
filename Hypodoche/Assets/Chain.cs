using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Chain : MonoBehaviour
    {
        [SerializeField] private float dmg;
        private float _duration = 5f;
        private float _startTime;

        public void Start(){
            _startTime = Time.time;
        }

        public void Update(){
   
            if(Time.time >= _startTime + _duration){
                Debug.Log("yep i am here");
                Destroy(gameObject);
            }
        }

        public void OnTriggerEnter(Collider col){
            return;
        }
    }
}
