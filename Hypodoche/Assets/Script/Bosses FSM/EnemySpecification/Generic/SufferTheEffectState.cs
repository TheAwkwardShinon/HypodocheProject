using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Hypodoche
{
    public class SufferTheEffectState : State
    {
        #region Variables
        //protected Collider _col;
        protected D_Entity _entityData;
        protected Effects trapEffect;
        protected string _json;
        protected string _typeOfCollision; //trap or player attacks or my own attacks
        #endregion

        //boss1 added only for testing
        #region Methods
        public SufferTheEffectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Effects effect ,string type)
            : base(entity, stateMachine, animationName)
        {
            _entityData = entityData;
            //_col = col;
            trapEffect = effect;
            _typeOfCollision = type;
        }


        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            _startTime = Time.time;
            Debug.Log("i am herreeeeee babe");
            if (_typeOfCollision.Equals("trap")) {
               
                //_effects = _col.gameObject.GetComponent<Traps>().SendDataTrap();
                //Debug.Log(_col.gameObject.GetComponent<Traps>().ToString());
                //Effects trapEffect = JsonUtility.FromJson<Effects>(_json); //todo change json to effect
                Debug.Log(trapEffect);
                if (trapEffect._isZone)
                    handleZone(trapEffect);
                else handleEffect(trapEffect);
            }
        }

        public override void Enter()
        {
            base.Enter();
            //TODO Controlla
            _animWaiter.StartCoroutine(_animWaiter.waitTillTheAnimationEnds(_entity._animator,this));
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }


        public void handleEffect(Effects trapEffect)
        {
            if (trapEffect._stun.isEmpty == false)
                gotStun(trapEffect._stun.time);
            if (trapEffect._slow.isEmpty == false)
                gotSlow(trapEffect._slow.speed, trapEffect._slow.time);
            if (trapEffect._damageOverTime.isEmpty == false)
                gotDamageOverTime(trapEffect._damageOverTime.damage, trapEffect._damageOverTime.time);
            if (trapEffect._damage.isEmpty == false)
                gotDamage(trapEffect._damage.damage);
            if (trapEffect._fear.isEmpty == false)
                gotScare(trapEffect._fear.whatScareMe, trapEffect._fear.timeOfFear);
        }


        public void handleZone(Effects trapEffect)
        {
            if (trapEffect._slowOverArea.isEmpty == false)
                slowOverArea(trapEffect._slowOverArea.speed);
            if (trapEffect._damageOverArea.isEmpty == false)
                DamageOverArea(trapEffect._damageOverArea.damage);
            if (trapEffect._enhance.isEmpty == false)
                EnancheOverArea(trapEffect._enhance.value);
        }


        public void healOverArea(float healValue) //not yet handled
        {
            return;
        }


        public void slowOverArea(float speed)
        {
            Debug.Log("SlowedOverArea");
            if (_entityData.isSlowed == true || _entityData.slowOverArea == true) return;
            _icons.AddSlow();
            _entityData.slowOverArea = true;
            _entityData.speedWhenSlowedArea = speed;
        }


        public void DamageOverArea(float damage)
        {
            Debug.Log("DmgOverArea");
            if (_entityData.damageOverArea == true) return;
            if (_entityData.gotDamageOverTime == false && _entityData.damageOverArea == false) _icons.AddDmgOverTime();
            _entityData.damageOverArea = true;
            _entityData.damageTakenOverTimeArea = damage;
        }


        public void EnancheOverArea(float multiplier)
        {
            Debug.Log("EnhanceOverArea");
            _entityData.enhanceMultiplier = multiplier;
        }

        public void gotStun(float time){
            Debug.Log("Stun");
            if (_entityData.isStun == true) return;
            _icons.AddStun();
            _entityData.isStun = true;
            _entityData.timeOfStun = time + Time.time;
        }

        public void gotDamage(float dmg)
        {
            Debug.Log("dmg");
            _entityData.health -= dmg + (dmg * _entityData.enhanceMultiplier);
            Enemy enemy = _entity.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(dmg + (dmg * _entityData.enhanceMultiplier));
           /* if (_entityData.health <= 0) return;
                _stateMachine.ChangeState(_deathState)*/
        }

        public void gotDamageOverTime(float dmg, float time)
        {
            _entityData.gotDamageOverTime = true;
            Debug.Log("dmgOverTime");
            if (_entityData.gotDamageOverTime == false && _entityData.damageOverArea == false) _icons.AddDmgOverTime();
            _entityData.timeOfDamage = time + Time.time;
            _entityData.startDmgOverTime = Time.time;
            _entityData.damageTakenOverTime = dmg;
        }

        public void gotSlow(float speed, float time)
        {
            Debug.Log("Slowed");
            if (_entityData.isSlowed == true || _entityData.slowOverArea == true) return;
            _icons.AddSlow();
            _entityData.isSlowed = true;
            _entityData.timeOfSlow = time + Time.time;
            _entityData.speedWhenSlowed = speed;
        }

        public virtual void gotScare(LayerMask whatScaresMe, float timeOfScare)
        {
            _entityData.whatIsScaringMe = whatScaresMe;
            _entityData.timeOfFear = timeOfScare;
            //be sure to get other effects first
        }


    }
    #endregion
}

