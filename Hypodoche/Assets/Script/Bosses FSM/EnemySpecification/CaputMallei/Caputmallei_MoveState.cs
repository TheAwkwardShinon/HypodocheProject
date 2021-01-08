using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Hypodoche{
    public class Caputmallei_MoveState : MoveState
    {

        #region variables
        private Caputmallei _caputmallei;
        #endregion

        #region methods
        public Caputmallei_MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Caputmallei caputmallei) : base(entity, stateMachine, animationName, entityData)
        {
            _caputmallei = caputmallei;
        }

        public override void Enter()
        {
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_caputmallei._deathState);
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (_entityData.isStun)
                return;
                
            if (_isDetectingWall)
            {
                _caputmallei._idleState.setFlipAfterIdle(true);
                setFromSufferEffect(false);
                _stateMachine.ChangeState(_caputmallei._idleState);
            }

            else if(_isDetectingPlayer){
                _stateMachine.ChangeState(_caputmallei._playerDetect);
            }

            else
            {
                if (_entityData.slowOverArea)
                {
                    _caputmallei.Move(_entityData.speedWhenSlowedArea);
                }
                else
                {
                    if (_entityData.isSlowed)
                        _caputmallei.Move(_entityData.speedWhenSlowed);
                    else _caputmallei.Move(_entityData.movementSpeed);
                }
            }
        }
        #endregion
    }
}
