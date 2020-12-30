using System.Collections;
using System.Collections.Generic;
using Hypodoche;
using UnityEngine;

public class PowerSurge : MonoBehaviour
{
    #region Variables
    protected float _recover = 50f;
    protected float _max_time = 50f;
    protected  float _countdown;
    private bool _isActive;
    private Animator _animator;
    #endregion

    #region methods
    public PowerSurge() {}

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }
        

    public void Update()
    {
        if(Time.time > _countdown)
        {
            _isActive = true;
            _animator.SetBool("isActive", true);
        }
    }
           
    void OnTriggerEnter(Collider  col)
    {
        if(_isActive && col.gameObject.CompareTag("Player"))
        {
            float maxHealth = col.gameObject.GetComponent<PlayerStatus>()._maxHealth;
            float currentHealth = col.gameObject.GetComponent<PlayerStatus>()._playerHealth;
            if(currentHealth < maxHealth){
                if (currentHealth + _recover >= maxHealth)
                    col.gameObject.GetComponent<PlayerStatus>()._playerHealth = maxHealth;
                else
                    col.gameObject.GetComponent<PlayerStatus>()._playerHealth += _recover;
                col.gameObject.GetComponent<PlayerStatus>().UpdateHealthUIValue();
                _countdown = Time.time + _max_time;
                _animator.SetBool("isActive", false);
            }
        }
    }

    #endregion
}
