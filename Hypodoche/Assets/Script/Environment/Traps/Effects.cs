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

    [Serializable]
    public struct FearData
    {
        public bool isEmpty;
        public LayerMask whatScareMe;
        public float timeOfFear;
    }
    
    [Serializable]
    public struct SlowOverAreaData
    {
        public bool isEmpty;
        public float speed;
    }

    [Serializable]
    public struct DamageOverAreaData
    {
        public bool isEmpty;
        public float damage;
    }
    
    [Serializable]
    public struct BlowerData
    {
        public bool isEmpty;
        public float strength;
        public Vector3 direction;
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
        [SerializeField] public FearData _fear;
        [SerializeField] public bool _isZone;
        [SerializeField] public SlowOverAreaData _slowOverArea;
        [SerializeField] public DamageOverAreaData _damageOverArea;
        [SerializeField] public bool _noDodge;
        [SerializeField] public bool _enhanceDamage;
        [SerializeField] public BlowerData _blower;
        #endregion

        #region methods
        public Effects(SlowData slow, StunData stun,
            DamageOverTimeData dmgT, DamageData dmg,FearData fear,bool isZone,SlowOverAreaData slowArea,
            DamageOverAreaData dmgArea,bool noDodge, bool enDmg,BlowerData blower)
        {
            _stun = stun;
            _slow = slow;
            _damageOverTime = dmgT;
            _damage = dmg;
            _fear = fear;
            _isZone = isZone;
            _slowOverArea = slowArea;
            _damageOverArea = dmgArea;
            _noDodge = noDodge;
            _enhanceDamage = enDmg;
            _blower = blower;
        }
        #endregion
    }
}