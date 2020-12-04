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
        protected bool _isDetectingPlayer;
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
            _isDetectingPlayer = _entity.isPlayerInAggroRange();
            setRandomIdleTime();
        }

        public override void Exit()
        {
            base.Exit();

            if (_flipAfterIdle)
            {
                _entity.Flip();
            }
        }

        public override void Update()
        {
            base.Update();
            _isDetectingPlayer = _entity.isPlayerInAggroRange();
            if (Time.time >= _startTime + _idleTime)
            {
                Debug.Log("idle time elapsed " + Time.time);
                _isIdleTimeElapsed = true;
            }
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