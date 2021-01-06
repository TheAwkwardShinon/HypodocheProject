using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Ice_MoveState : MoveState
    {

        private IceCrow _crow;
        public Ice_MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, IceCrow crow) : base(entity, stateMachine, animationName, entityData)
        {
            _crow = crow;
        }

        public override void Enter()
        {
            base.Enter();

        }
        public override void Exit(){
            base.Exit();
        }

        public override void Update(){
            base.Update();
            _crow.setPlayerPosition(_crow.isPlayerInAggroRange());
            if(Time.time >= _crow.getTimer()+ _crow.getUnBreakableBondCountDown()){
                _stateMachine.ChangeState(_crow._unbreakableBond);
            }
            if (_isDetectingWall)
            {
                _crow._IdleState.setFlipAfterIdle(true);
                _stateMachine.ChangeState( _crow._IdleState);
            }
            else{
                _crow.Move(_entityData.movementSpeed);
            }
        }
    }
}