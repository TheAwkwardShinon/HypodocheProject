using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class LiYan_MoveState : MoveState
    {
        #region Variables
        private LiYan _liYan;
        private float _startTimeFast;
        private float _startTimeSlow;
        private bool _isFast;
        private bool _isSlow;
        private bool _varSpeed;


        public LiYan_MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, LiYan liYan)
            : base(entity, stateMachine, animationName, entityData)
        {
            _liYan = liYan;
        }
        #endregion

        #region Methods
        public override void Enter()
        {
            base.Enter();
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_liYan._deathState);
            _isFast = false;
            _startTimeFast = _startTime + _liYan.changeSpeedToFast;

        }

        public override void Exit()
        {
            base.Exit();
        }


        public void checkTime()
        {
            if (Time.time >= _liYan.timerBomb + _liYan.dropBombTimeRate) 
                _stateMachine.ChangeState(_liYan._DropBombState);
            if (_isFast)
            {
                if (Time.time >= _startTimeFast)
                {
                    _isSlow = true;
                    _startTimeSlow = _startTime + _liYan.changeSpeedToSlow;
                }
            }
            else
            {
                if (Time.time >= _startTimeSlow)
                {
                    _isFast = true;
                    _startTimeFast = _startTime + _liYan.changeSpeedToFast;
                }
            }
        }


        public override void Update()
        {
            base.Update();

            checkTime();
            if (_entityData.isStun)
                return;
            if (_isDetectingWall)
            {
                _liYan._idleState.setFlipAfterIdle(true);
                _stateMachine.ChangeState(_liYan._idleState);
            }
            else
            {
                if (_entityData.slowOverArea)
                {
                    _liYan.Move(_entityData.speedWhenSlowedArea);
                }
                else
                {
                    if (_entityData.isSlowed)
                        _liYan.Move(_entityData.speedWhenSlowed);
                    else if (_entityData.isStun)
                        return;
                    else if (_isSlow)
                        _liYan.Move(_entityData.movementSpeed / 2); //move 50% speed less
                    else _liYan.Move(_entityData.movementSpeed);
                }
            }
        }



        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        #endregion
    }
}
