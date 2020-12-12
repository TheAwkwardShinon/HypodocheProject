using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class SubZeroRay : MonoBehaviour,Traps
    {
        #region variables
        public GameObject bullet;
        Effects myEffect;
        #endregion

        #region methods
        public SubZeroRay() {}

        public void Start()
        {
            InvokeRepeating("Shoot", 0.0f, 8.0f); // 8 sec cd
        }

        void OnTriggerEnter(Collider col)
        {
            
        }

        public void Shoot()
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            //positioning the bullet s.t. comes out from the subzero
            obj.transform.SetParent(gameObject.transform);
            obj.transform.position = gameObject.transform.position;
            
        }

        public string SendDataTrap()  //not used
        {
            Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }
            
        #endregion
    }
        
}