using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class SubZeroRay : MonoBehaviour,Traps
    {
        #region variables
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _shootingPoint;
        private Animator _animator;
        Effects _myEffect;
        #endregion

        #region methods
        public SubZeroRay() {}

        public void Start()
        {
            _animator = GetComponent<Animator>();
            if(gameObject.transform.position.x > 0)
                gameObject.transform.rotation = Quaternion.Euler(-45,180, gameObject.transform.rotation.z);
            StartCoroutine(Shoot());
        }

        void OnTriggerEnter(Collider col)
        {
            //EMPTY//
        }

        private IEnumerator Shoot()
        {
            while(Application.isPlaying){
                _animator.SetTrigger("Shoot");
                GameObject obj = (GameObject)Instantiate(_bullet, _shootingPoint.position, _shootingPoint.rotation);
                yield return new WaitForSeconds(8f);
            }
        }

        public string SendDataTrap()  //not used
        {
            //EMPTY//
            return null;
        }
            
        #endregion
    }
        
}