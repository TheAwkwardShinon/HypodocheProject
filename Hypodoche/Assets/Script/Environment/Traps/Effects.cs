using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Hypodoche
{

    #region structures
    [Serializable]
    public struct StunData
    {
        public bool isEmpty;
        public float time;
    }

    [Serializable]
    public struct SlowData
    {
        public bool isEmpty;
        public float time;
        public float speed;
    }

    [Serializable]
    public struct DamageOverTimeData
    {
        public bool isEmpty;
        public float time;
        public float damage;
    }

    [Serializable]
    public struct DamageData
    {
        public bool isEmpty;
        public float damage;
    }
    #endregion

    [Serializable]
    public class Effects
    {
        #region variables
        [SerializeField] public StunData _stun;
        [SerializeField] public SlowData _slow;
        [SerializeField] public DamageOverTimeData _damageOverTime;
        [SerializeField] public DamageData _damage;
        #endregion

        #region methods
        public Effects(SlowData slow, StunData stun,
            DamageOverTimeData dmgT, DamageData dmg)
        {
            _stun = stun;
            _slow = slow;
            _damageOverTime = dmgT;
            _damage = dmg;
        }
        #endregion
    }
}