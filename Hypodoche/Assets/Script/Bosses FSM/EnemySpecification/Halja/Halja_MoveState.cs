using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Hypodoche{
    public class Halja_MoveState : MoveState
    {

        #region variables
        private Halja _halja;
        #endregion

        #region methods
        public Halja_MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Halja halja) : base(entity, stateMachine, animationName, entityData)
        {
            _halja = halja;
        }

        public override void Enter()
        {
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_halja._deathState);
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if (Time.time >= _halja.timerUnbreakableBond + _halja.unbreakableBondCountdown)
                _stateMachine.ChangeState(_halja._unbreakableBond);

            if (_entityData.isStun)
                return;
                
            else if (_isDetectingWall)
            {
                _halja._idleState.setFlipAfterIdle(true);
                setFromSufferEffect(false);
                _stateMachine.ChangeState(_halja._idleState);
            }
            else if(_isDetectingPlayer){
                _stateMachine.ChangeState(_halja._playerDetectState);
            }
            else
            {
                if (_entityData.slowOverArea)
                {
                    _halja.Move(_entityData.speedWhenSlowedArea);
                }
                else
                {
                    if (_entityData.isSlowed)
                        _halja.Move(_entityData.speedWhenSlowed);
                    else _halja.Move(_entityData.movementSpeed);
                }
            }
        }
        #endregion
    }
}
