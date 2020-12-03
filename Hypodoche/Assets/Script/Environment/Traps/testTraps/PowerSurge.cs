using System.Collections;
using System.Collections.Generic;
using Hypodoche;
using UnityEngine;

public class PowerSurge : MonoBehaviour
{
    #region Variables
    public float recover = 50;
    public float max_time = 50;
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
            countdown = countdown - 1;
            if (countdown == 0)
            {
                countdown = max_time;
                timeIsRunning = false;
                idle = false;
            }
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

    #endregion
}
