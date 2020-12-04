using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Hypodoche
{
    public class SufferTheEffectState : State
    {
        #region Variables
        protected Collider _col;
        protected D_Entity _entityData;
        protected string _effects;
        protected string _typeOfCollision; //trap or player attacks or my own attacks
        #endregion

        //boss1 added only for testing
        #region Methods
        public SufferTheEffectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Collider col,string type)
            : base(entity, stateMachine, animationName)
        {
            _entityData = entityData;
            _col = col;
            _typeOfCollision = type;
        }

        public override void Enter()
        {
            base.Enter();
            //TODO Controlla
            /*
            if (_typeOfCollision.Equals("trap")) {
                Debug.Log("col con : " + _col.gameObject);
                _effects = _col.gameObject.GetComponent<Traps>().SendDataTrap();
                Effects trapEffect = JsonUtility.FromJson<Effects>(_effects);
                if (trapEffect._isZone)
                    handleZone(trapEffect);
                else handleEffect(trapEffect);
            }*/
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
            _entityData.slowOverArea = true;
            _entityData.speedWhenSlowedArea = speed;
        }


        public void DamageOverArea(float damage)
        {
            _entityData.damageOverArea = true;
            _entityData.damageTakenOverTimeArea = damage;
        }


        public void EnancheOverArea(float multiplier)
        {
            _entityData.enhanceMultiplier = multiplier;
        }

        public void gotStun(float time){

            _entityData.isStun = true;
            _entityData.timeOfStun = time;
        }

        public void gotDamage(float dmg)
        {

            _entityData.health -= dmg + (dmg * _entityData.enhanceMultiplier);
            Enemy enemy = _entity.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(dmg + (dmg * _entityData.enhanceMultiplier));
           /* if (_entityData.health <= 0) return;
                _stateMachine.ChangeState(_deathState)*/
        }

        public void gotDamageOverTime(float dmg, float time)
        {

            _entityData.gotDamageOverTime = true;
            _entityData.timeOfDamage = time;
            _entityData.damageTakenOverTime = dmg;
        }

        public void gotSlow(float speed, float time)
        {
   
            _entityData.isSlowed = true;
            _entityData.timeOfSlow = time;
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

