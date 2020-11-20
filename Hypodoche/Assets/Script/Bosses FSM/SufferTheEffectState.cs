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
            public Boss1 _boss; //testing
        #endregion

        //boss1 added only for testing
        #region Methods
        public SufferTheEffectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Collider col, Boss1 boss)
            : base(entity, stateMachine, animationName)
        {
            _entityData = entityData;
            _col = col;
            _boss = boss; //only testing
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("suffer the effect state");
            //TODO TUTTO QUESTO SE è UNA TRAPPOLA 
            _effects = _col.gameObject.GetComponent<Traps>().SendDataTrap(); 
            Debug.Log(_effects);
            Effects trapEffect = JsonUtility.FromJson<Effects>(_effects);
            if (trapEffect._stun.isEmpty == false)
                gotStun(trapEffect._stun.time);
            if (trapEffect._slow.isEmpty == false)
                gotSlow(trapEffect._slow.speed, trapEffect._slow.time);
            if (trapEffect._damageOverTime.isEmpty == false)
                gotDamageOverTime(trapEffect._damageOverTime.damage, trapEffect._damageOverTime.time);
            if (trapEffect._damage.isEmpty == false)
                gotDamage(trapEffect._damage.damage);

            //only for testing
            
            _stateMachine.ChangeState(_boss._moveState);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }

        public void gotStun(float time){
            Debug.Log("called stun");
            _entityData.isStun = true;
            _entityData.timeOfStun = time;
        }

        public void gotDamage(float dmg)
        {
            Debug.Log("called damage");
            _entityData.health -= dmg;
            if (_entityData.health <= 0) return;
                //_stateMachine.ChangeState(deathState) toBEimplemented
                //_entity._boss.Destroy(); //per ora
        }

        public void gotDamageOverTime(float dmg, float time)
        {
            Debug.Log("called damageOverTime");
            _entityData.gotDamageOverTime = true;
            _entityData.timeOfDamage = time;
            _entityData.damageTakenOverTime = dmg;
        }

        public void gotSlow(float speed, float time)
        {
            Debug.Log("called slow");
            _entityData.isSlowed = true;
            _entityData.timeOfSlow = time;
            _entityData.speedWhenSlowed = speed;
        }

        public void gotScare(LayerMask whatScaresMe, float timeOfScare)
        {
            //it may be better to add some info in entityData.
            //be sure to get other effects first
            //changeState(new ScaredState(whatScaresMe, timeOfScare, etc...) //to be modified
            return;
        }


    }
    #endregion
}

