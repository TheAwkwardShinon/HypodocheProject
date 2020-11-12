using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class B1_ChaseState : State
    {
        #region Variables
        protected Transform _playerTransform;
        protected Vector3 _playerPosition;
        protected float _minDistanceFromPlayer;
        protected float _speedWhenDetect;
        protected Boss1 _boss;
        #endregion

        #region Methods
        public B1_ChaseState(Entity entity, FiniteStateMachine stateMachine, string animationName, Transform playerPosition, float distanceIwantToBE,float speed, Boss1 boss)
            : base(entity, stateMachine, animationName)
        {
            _playerTransform = playerPosition;
            _minDistanceFromPlayer = distanceIwantToBE;
            _speedWhenDetect = speed;
            _boss = boss;
        }


        public override void Enter()
        {
            base.Enter();
            _playerPosition = _playerTransform.position;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            _playerPosition = _playerTransform.position;
            float dstToTarget = Vector3.Distance(_boss.transform.position, _playerPosition);
            if (_minDistanceFromPlayer < dstToTarget)
            {
                _boss.transform.position = Vector3.MoveTowards(_boss.transform.position, _playerPosition, _speedWhenDetect * Time.fixedDeltaTime);
                //_boss.transform.position += _playerPosition * _speedWhenDetect * Time.fixedDeltaTime;
            }
             
            else _stateMachine.ChangeState(_boss._playerDetectState);
        }

        #endregion
    }
}