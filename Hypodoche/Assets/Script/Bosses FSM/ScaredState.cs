using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class scaredState : State
    {
        #region Variables
        protected D_ScaredState _scaredData;
        protected float _scaredTime;
        protected bool _isScaredTimeElapsed;
        //protected bool _isDetectingPlayer;
        #endregion

        #region Methods
        public scaredState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_ScaredState scaredData)
            : base(entity, stateMachine, animationName)
        {
            _scaredData = scaredData;
        }


        public override void Enter()
        {
            base.Enter();
            _entity.setDirection();
            _isScaredTimeElapsed = false;
            setRandomScaredTime();
        }

        public override void Exit()
        {
            base.Exit();

        }

        public override void Update()
        {
            base.Update();
            if (Time.time >= _startTime + _scaredTime)
            {
                _isScaredTimeElapsed = true;
            }
        }


        public void setRandomScaredTime()
        {
            _scaredTime = UnityEngine.Random.Range(_scaredData.minScaredTime, _scaredData.maxScaredTime);
        }
        #endregion
    }
}
