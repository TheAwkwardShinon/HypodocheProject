using System.Collections;
using System.Collections.Generic;
using Hypodoche;
using UnityEngine;

public class PowerSurge : MonoBehaviour
{
    #region Variables
    [SerializeField] protected float _recover = 30f;
    [SerializeField] protected float _max_time = 30f;
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
            float maxHealth = col.gameObject.GetComponent<PlayerStatus>().GetMaxHealth();
            float currentHealth = col.gameObject.GetComponent<PlayerStatus>().GetPlayerHealth();
            if(currentHealth < maxHealth){
                if (currentHealth + _recover >= maxHealth)
                    col.gameObject.GetComponent<PlayerStatus>().SetPlayerHealth(maxHealth);
                else
                    col.gameObject.GetComponent<PlayerStatus>().SetPlayerHealth(currentHealth + _recover);
                _countdown = Time.time + _max_time;
                _animator.SetBool("isActive", false);
            }
        }
    }

    #endregion
}
