using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class IdleState : State
    {
        #region Variables
        protected D_IdleState _idleData;
        protected bool _flipAfterIdle;
        protected float _idleTime;
        protected bool _isIdleTimeElapsed;
        #endregion

        #region Methods
        public IdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_IdleState idleData)
            : base(entity, stateMachine, animationName)
        {
            _idleData = idleData;
        }


        public override void Enter()
        {
            base.Enter();
            _entity.setDirection();
            _isIdleTimeElapsed = false;
            setRandomIdleTime();
        }

        public override void Exit()
        {
            base.Exit();

            if (_flipAfterIdle)
            {
                _entity.Flip(); //mi giro di 180 gradi dal lato opposto. peroò sull'asse delle ascisse. Non so come gestire le ordinate, sarebbe visivamente brutto
            }
        }

        public override void Update()
        {
            base.Update();
            if (Time.time >= _startTime + _idleTime)
            {
                _isIdleTimeElapsed = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public void setFlipAfterIdle(bool flip)
        {
            _flipAfterIdle = flip;
        }

        public void setRandomIdleTime()
        {
            _idleTime = UnityEngine.Random.Range(_idleData.minIdleTime, _idleData.maxIdleTime);
        }
        #endregion
    }
}
