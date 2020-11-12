using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class charmedState : State
    {
        #region Variables
        protected D_CharmedState _charmedData;
        protected float _charmedTime;
        protected bool _isCharmedTimeElapsed;
        //protected bool _isDetectingPlayer;
        #endregion

        #region Methods
        public charmedState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_CharmedState charmedData)
            : base(entity, stateMachine, animationName)
        {
            _charmedData = charmedData;
        }


        public override void Enter()
        {
            base.Enter();
            _entity.setDirection();
            _isCharmedTimeElapsed = false;
            setRandomCharmedTime();
        }

        public override void Exit()
        {
            base.Exit();

        }

        public override void Update()
        {
            base.Update();
            if (Time.time >= _startTime + _charmedTime)
            {
                _isCharmedTimeElapsed = true;
            }
        }


        public void setRandomCharmedTime()
        {
            _charmedTime = UnityEngine.Random.Range(_charmedData.minCharmedTime, _charmedData.maxCharmedTime);
        }
        #endregion
    }
}
