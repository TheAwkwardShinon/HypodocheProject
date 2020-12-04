using System.Collections;
using System.Collections.Generic;
using Hypodoche;
using UnityEngine;

public class PowerSurge : MonoBehaviour
{
    #region Variables
    public float recover = 50f;
    public float max_time = 50f;
    public float countdown;
    public bool timeIsRunning;
    public bool idle;
    #endregion

    #region methods
    public PowerSurge() {}

    public void Start()
    {
        countdown = max_time;
        timeIsRunning = false;
        idle = false;
    }
        

    public void Update()
    {
        if (timeIsRunning)
        {
            CooldownTimer(Time.deltaTime);
        }
    }
        
        
    void OnTriggerEnter(Collider  col)
    {
        if(col.gameObject.CompareTag("Player") && !idle)
        {
            timeIsRunning = true;
            idle = true;
            float max_health = col.gameObject.GetComponent<PlayerStatus>()._maxHealth;
            float current_health = col.gameObject.GetComponent<PlayerStatus>()._playerHealth;
            if ((max_health - current_health) < recover)
                col.gameObject.GetComponent<PlayerStatus>()._playerHealth = max_health;
            else
                col.gameObject.GetComponent<PlayerStatus>()._playerHealth += recover;
            col.gameObject.GetComponent<PlayerStatus>().UpdateHealthUIValue();
        }
    }

    private void CooldownTimer(float delta){
        countdown += delta;
        if(countdown % 60 > max_time){
            timeIsRunning = false;
            idle = false;
            countdown = 0f;
        }
    }

    #endregion
}
