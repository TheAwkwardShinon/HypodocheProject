using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hypodoche
{
    public class Blower : MonoBehaviour,Traps
    {
        #region variables

        [SerializeField]public float Strength;
        [SerializeField] public Vector3 WindDirection;
        
        Effects myEffect;
        //public string direction;
        #endregion

        #region methods
        public Blower() {}

        public void Start()
        {
        }
        

        public void Update()
        {
            //if you want the trap to do something special
        }
        
        void OnTriggerEnter(Collider col)  // gives the bouncing effect
        {
            Rigidbody colRigidbody = col.GetComponent<Rigidbody>();
            if (colRigidbody != null)
            {
                colRigidbody.AddForce(WindDirection * Strength);
            }
        }
        
        public string SendDataTrap()
        {
            //Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }

        #endregion
    }
}

