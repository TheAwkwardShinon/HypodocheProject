using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Ice_idleState : IdleState
    {
        private IceCrow _crow;
        public Ice_idleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_IdleState idleData, IceCrow crow) : base(entity, stateMachine, animationName, idleData)
        {
            _crow = crow;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            _crow.setPlayerPosition(_crow.isPlayerInAggroRange());

            if(!_crow.IsIneluttable()){
                if(_isDetectingPlayer){
                    _stateMachine.ChangeState(_crow._PlayerDetect);
                }
            }

            if(Time.time >=_crow.getTimer() + _crow.getUnBreakableBondCountDown()){
                _stateMachine.ChangeState(_crow._unbreakableBond);
            }
             if (_isIdleTimeElapsed){
                _stateMachine.ChangeState(_crow._MoveState);
             }
            
        }
    }
}