using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Hypodoche
{
    public class LuckyStar : MonoBehaviour,Traps
    {
        #region variables
        private  float countdown = 0f;
        [SerializeField]private float _activeTime = 8f;
        [SerializeField]private float _deadTime = 5f;

        private Animator _anim;
        
        private bool _active = false;

        protected Collider _myCollider;
        private Effects myEffect;

        private SpriteRenderer _sprite;

        private Color _colorValue;
  
        #endregion

        #region methods


        public void Start()
        {
            _myCollider = gameObject.GetComponent<Collider>();
            _sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
            _colorValue = Color.white;
            _anim = GetComponent<Animator>();
            _anim.SetBool("isActive", false);
        }
        

        public void Update()
        {
            if(!_active){ 
                {
                //_colorValue.a = _colorValue.a - 0.05f <= 0f ? 0f : _colorValue.a - 0.05f;
                //_sprite.color = _colorValue;
                }
            }
            else{
               // _colorValue.a = _colorValue.a + 0.05f >= 1f ? 1f : _colorValue.a + 0.05f;
                //_sprite.color = _colorValue;
            }

            if (!_active && Time.time >= countdown) { 
                _active = true;
                _anim.SetBool("isActive", true);

                countdown = Time.time + _activeTime; 
            }
            if (_active && Time.time >= countdown)
            {
                _active = false;
                _anim.SetBool("isActive", false);

                countdown = Time.time + _deadTime;
            }

            if (_active && !_myCollider.enabled)
            {
                _myCollider.enabled = true;
            }
            else if(!_active && _myCollider.enabled)
                _myCollider.enabled = false;
        }
        
        
        void OnTriggerEnter(Collider  col)
        {
            if(col.gameObject.CompareTag("Bomb"))
            {
                col.GetComponent<RocketInterface>().DestroyRocket();
             
            }
        }

        public string SendDataTrap()
        {
            Destroy(gameObject);
            return JsonUtility.ToJson(myEffect, true);
        }

       
        #endregion
    }
}