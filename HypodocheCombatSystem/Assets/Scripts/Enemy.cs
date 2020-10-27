using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class Enemy : MonoBehaviour
    {
        #region Variables
        private float _health = 100;
        #endregion

        #region Methods
        public void TakeDamage(float damage)
        {
            _health -= damage;
            Debug.Log("Health is:" + _health);
            if (_health <= 0)
                Destroy(gameObject);
        }
        #endregion
    }
}
