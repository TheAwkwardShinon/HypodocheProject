using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class ScaredState : State
    {
        #region Variables
        protected D_Entity _entityData;
        protected float _scaredTime;
        protected bool _isScaredTimeElapsed;
        //protected bool _isDetectingPlayer;
        #endregion

        #region Methods
        public ScaredState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData)
            : base(entity, stateMachine, animationName)
        {
            _entityData = entityData;
        }


        public override void Enter()
        {
            base.Enter();
            _entity.setDirection();
            _isScaredTimeElapsed = false;
            _scaredTime = _entityData.timeOfFear;
            //setRandomScaredTime();
        }

        public override void Exit()
        {
            base.Exit();

        }

        public override void Update()
        {
           
            base.Update();
            /*
            if (Time.time >= _startTime + _scaredTime)
            {
                _isScaredTimeElapsed = true;
                _entityData.timeOfFear = 0f;
                _stateMachine.ChangeState()
            }
            _entityData.Move();*/
        }

/*
        public void setRandomScaredTime()
        {
            _scaredTime = UnityEngine.Random.Range(_scaredData.minScaredTime, _scaredData.maxScaredTime);
        }*/
        #endregion
    }
}
