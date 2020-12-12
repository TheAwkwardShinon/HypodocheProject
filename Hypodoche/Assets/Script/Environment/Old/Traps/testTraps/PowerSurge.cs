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
    #endregion

    #region methods
    public PowerSurge() {}

    public void Start()
    {

    }
        

    public void Update()
    {

    }
           
    void OnTriggerEnter(Collider  col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if (Time.time <= _countdown)
                return;
            float max_health = col.gameObject.GetComponent<PlayerStatus>()._maxHealth;
            float current_health = col.gameObject.GetComponent<PlayerStatus>()._playerHealth;
            if (current_health + _recover >= max_health)
                col.gameObject.GetComponent<PlayerStatus>()._playerHealth = max_health;
            else
                col.gameObject.GetComponent<PlayerStatus>()._playerHealth += _recover;
            col.gameObject.GetComponent<PlayerStatus>().UpdateHealthUIValue();
            _countdown = Time.time + _max_time;
        }
    }

    #endregion
}
